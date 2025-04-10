namespace ParkingManagement.Models.Responses
{
    public class GetUserByIdResponse
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Photo { get; set; }
        public string? CoverPhoto { get; set; }
    }
}
