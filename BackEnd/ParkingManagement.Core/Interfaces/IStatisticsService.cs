using ParkingManagement.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Core.Interfaces
{
    public interface IStatisticsService
    {
        Task<AnalyticsDTO> GetTotalsAsync();
    }
}
