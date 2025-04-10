namespace ParkingManagement.Core.Entities
{
    public class ArtisanClientService
    {
        public int Id { get; set; }
        public DateTime ServiceDate { get; set; }
        public Parking Parking { get; set; }
        public int ParkingId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Artisan Artisan { get; set; }
        public int ArtisanId { get; set; }
        public ServiceState Status { get; set; }
    }

}
