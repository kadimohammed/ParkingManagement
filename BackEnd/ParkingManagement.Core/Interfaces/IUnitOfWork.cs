
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Interfaces
{
    public  interface IUnitOfWork
    {
        IParkingRepository ParkingRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        Task<int> SaveChangesAsync();
    }
}
