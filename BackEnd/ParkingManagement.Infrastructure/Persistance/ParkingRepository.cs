using Microsoft.EntityFrameworkCore;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Infrastructure.Persistance.Data;

namespace ParkingManagement.Infrastructure.Persistance
{
    public class ParkingRepository : IParkingRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<Parking> _entities;

        public ParkingRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<Parking>();
        }

        public async Task AddAsync(Parking model)
        {
            await _entities.AddAsync(model);
        }

        public async Task DeleteAsync(Parking model)
        {
            _entities.Remove(model);
        }

        public async Task<IEnumerable<Parking>> GetAllAsync()
        {
            return await _entities.Include(p => p.ParkingDays).ToListAsync();
        }

        public async Task<Parking> GetByIdAsync(int id)
        {
            return await _entities.Include(p => p.ParkingDays).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Parking model)
        {
            _entities.Update(model);
        }
    }
}
