window.initializeMap = function (latitude, longitude, title, isMultiple, parkingsData, address) {
    if (window.map) {
        window.map.remove();
    }

    // Creer la carte
    window.map = L.map('customMap').setView([latitude, longitude], isMultiple ? 12 : 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(window.map);

    var imgTest = new Image();

    imgTest.onload = function () {
        var customIcon = L.icon({
            iconUrl: 'images/parkingMarker.png',
            iconSize: [48, 48],
            iconAnchor: [15, 48],
            popupAnchor: [0, -48]
        });

        if (isMultiple && parkingsData) {
            parkingsData.forEach(function (parking) {
                var marker = L.marker([parking.lat, parking.lng], { icon: customIcon }).addTo(window.map);
                marker.bindPopup("<b>" + parking.name + "</b><br>" +
                    "<span>" + parking.address + "</span><br>" +
                    "<span>" + parking.lat + " " + parking.lng + "</span><br>" +
                    "<a href='/parking/Details/" + parking.id + "'>Voir détails</a><br>")
                    .on('click', function () {
                        marker.openPopup();
                    });
            });
        } else {
            var marker = L.marker([latitude, longitude], { icon: customIcon }).addTo(window.map);
            marker.bindPopup("<b>" + title + "</b><br>" +
                "<span>" + address + "</span><br>" +
                "<span>" + latitude + " " + longitude + "</span><br>").openPopup();
        }
    };

    imgTest.src = 'images/parkingMarker.png';

    // Force a map resize after a short delay
    setTimeout(function () {
        window.map.invalidateSize();
    }, 200);
};