namespace ParkingManagement.Core.Entities
{
    public class ArtisanType
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public IList<Artisan>? Artisans { get; set; }
    }
}
