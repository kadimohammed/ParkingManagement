namespace ParkingManagement.Core.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public IList<ArtisanImage>? ArtisanImages { get; set; }
    }
}
