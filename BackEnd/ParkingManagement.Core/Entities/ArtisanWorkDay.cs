namespace ParkingManagement.Core.Entities
{
    public class ArtisanWorkDay
    {
        public int Id { get; set; }
        public Artisan Artisan { get; set; }
        public int ArtisanId { get; set; }
        public Day Day { get; set; }
    }
}
