using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Core.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetTotalArtisanAsync();
        Task<int> GetTotalClientsAsync();
        Task<int> GetTotalParkingsAsync();
    }
}
