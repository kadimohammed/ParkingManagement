using Microsoft.EntityFrameworkCore;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Infrastructure.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            return client;
        }

        public async Task<User> GetByEmailAndPasswordAsync(string Email, string Password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);
        }


        public async Task<User> GetClientByEmailAsync(string Email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
        }

        public async Task<User> GetClientByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
