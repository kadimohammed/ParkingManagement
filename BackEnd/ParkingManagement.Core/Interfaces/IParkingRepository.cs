
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Interfaces
{
    public interface IParkingRepository
    {
        Task<Parking> GetByIdAsync(int id);
        Task<IEnumerable<Parking>> GetAllAsync();
        Task AddAsync(Parking model);
        Task UpdateAsync(Parking model);
        Task DeleteAsync(Parking model);
    }
}
