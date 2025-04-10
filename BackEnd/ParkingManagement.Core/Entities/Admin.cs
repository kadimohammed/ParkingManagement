using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.Entities
{
    public class Admin : User
    {
        [Range(0,5)]
        public int Rating { get; set; }
    }
}
