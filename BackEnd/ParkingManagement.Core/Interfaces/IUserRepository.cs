using ParkingManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Core.Interfaces
{
    public  interface IUserRepository
    {
        Task<User> GetByEmailAndPasswordAsync(string Email, string Password);
        Task<Client> AddClientAsync(Client client);
        Task<User> GetClientByEmailAsync(string Email);
        Task<User> GetClientByIdAsync(int Id);
    }
}
