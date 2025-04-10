namespace ParkingManagement.Core.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string NomParcking { get; set; }
        public string Adresse { get; set; }
        public double Surface { get; set; }
        public TimeOnly TimeStartWork { get; set; }
        public TimeOnly TimeEndWork { get; set; }
        public DateOnly CreationDate { get; set; }
        public bool IsWorking { get; set; }
        public string Picture { get; set; }
        public IList<ParkingDay>? ParkingDays { get; set; } = new List<ParkingDay>();
        public IList<ArtisanClientService>? artisanClientServices { get; set; } = new List<ArtisanClientService>();

    }
}