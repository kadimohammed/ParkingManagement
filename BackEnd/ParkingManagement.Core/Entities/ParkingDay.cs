namespace ParkingManagement.Core.Entities
{
    public class ParkingDay
    {
        public int Id { get; set; }
        public Parking? Parking { get; set; }
        public int ParkingId { get; set; }
        public Day Day { get; set; }
    }
}
