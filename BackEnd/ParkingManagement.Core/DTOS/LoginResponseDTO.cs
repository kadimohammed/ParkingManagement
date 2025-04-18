﻿

namespace ParkingManagement.Core.DTOS
{
    public class LoginResponseDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Photo { get; set; }
        public string? Role { get; set; }
    }
}
