using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Core.Interfaces
{
    public interface IParkingService
    {
        Task<IEnumerable<Parking>> GetAllParkings();
        Task<Parking> GetParkingById(int Id);
        Task DeleteParking(Parking parking);
        Task<Parking> AddParking(AddParkingDTO newParking, string PictureName);
        Task<Parking> UpdateParking(UpdateParkingDTO newParking, string PictureName);

    }
}
