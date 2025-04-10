namespace ParkingManagement.Core.Entities
{
    public class ClientParking
    {
        public int Id { get; set; }
        public DateTime DatePark { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
