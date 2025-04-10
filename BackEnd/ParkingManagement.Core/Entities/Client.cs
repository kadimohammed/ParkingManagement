namespace ParkingManagement.Core.Entities
{
    public class Client : User
    {
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public IList<ArtisanClientService>? ArtisanClientServices { get; set; }
        public IList<ClientParking>? ClientParkings { get; set; }
    }

}
