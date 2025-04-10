using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.Entities
{
    public class Artisan : User
    {
        public string Address { get; set; }
        public string Profession { get; set; }
        public int YearsOfExperience { get; set; }
        [Range(0, 100)]
        public int Rating { get; set; }
        public string Description { get; set; }
        public string TrailerUrl { get; set; }
        public ArtisanType? Type { get; set; }
        public int ArtisanTypeId { get; set; }
        public bool IsActive { get; set; }
        public IList<ArtisanClientService>? ArtisanClientServices { get; set; }
        public IList<ArtisanWorkDay>? ArtisanWorkDays { get; set; }
        public IList<ArtisanImage>? ArtisanImages { get; set; }
    }

}
