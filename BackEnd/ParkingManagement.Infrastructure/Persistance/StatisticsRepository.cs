using Microsoft.EntityFrameworkCore;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Infrastructure.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Infrastructure.Persistance
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext _context;

        public StatisticsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalArtisanAsync()
        {
            return await _context.Artisans.CountAsync();
        }

        public async Task<int> GetTotalClientsAsync()
        {
            return await _context.Clients.CountAsync();
        }

        public async Task<int> GetTotalParkingsAsync()
        {
            return await _context.parkings.CountAsync();
        }
    }
}
