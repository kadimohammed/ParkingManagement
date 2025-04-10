using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Infrastructure.Persistance.Data;

namespace ParkingManagement.Infrastructure.Persistance
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IParkingRepository ParkingRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ParkingRepository = new ParkingRepository(context);
            UserRepository = new UserRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
