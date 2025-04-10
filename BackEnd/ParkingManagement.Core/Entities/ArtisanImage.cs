namespace ParkingManagement.Core.Entities
{
    public class ArtisanImage
    {
        public int Id { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }
        public Artisan Artisan { get; set; }
        public int ArtisanId { get; set; }
    }
}
