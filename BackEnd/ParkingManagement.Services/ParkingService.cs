using AutoMapper;
using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Interfaces;

namespace ParkingManagement.Services
{
    public class ParkingService : IParkingService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper _mapper { get; set; }

        public ParkingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Parking>> GetAllParkings()
        {
            return await _unitOfWork.ParkingRepository.GetAllAsync();
        }

        public async Task<Parking> GetParkingById(int Id)
        {
            return await _unitOfWork.ParkingRepository.GetByIdAsync(Id);
        }

        public async Task DeleteParking(Parking parking) 
        {
            await _unitOfWork.ParkingRepository.DeleteAsync(parking);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Parking> AddParking(AddParkingDTO newParking,string PictureName)
        {
            Parking parking = _mapper.Map<Parking>(newParking);
            parking.Picture = PictureName;
            int cmp = 0;

            foreach (var day in newParking.Days)
            {
                if (day)
                {
                    ParkingDay parkday = new ParkingDay
                    {
                        ParkingId = parking.Id,
                        Day = (Day)cmp
                    };
                    parking.ParkingDays?.Add(parkday);
                }
                cmp++;
            }

            await _unitOfWork.ParkingRepository.AddAsync(parking);
            await _unitOfWork.SaveChangesAsync();

            return parking;
        }


        public async Task<Parking> UpdateParking(UpdateParkingDTO newParking, string PictureName)
        {
            Parking parking = await _unitOfWork.ParkingRepository.GetByIdAsync(newParking.Id);
            _mapper.Map(newParking, parking);
            parking.Picture = PictureName;
            parking.ParkingDays?.Clear();

            int cmp = 0;
            foreach (var day in newParking.Days)
            {
                if (day)
                {
                    ParkingDay parkday = new ParkingDay
                    {
                        ParkingId = parking.Id,
                        Day = (Day)cmp
                    };
                    parking.ParkingDays?.Add(parkday);
                }
                cmp++;
            }

            await _unitOfWork.ParkingRepository.UpdateAsync(parking);
            await _unitOfWork.SaveChangesAsync();

            return parking;
        }

    }
}
