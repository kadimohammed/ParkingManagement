using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Core.DTOS
{
    public class AnalyticsDTO
    {
        public int ParkingsCount { get; set; }
        public int ClientsCount { get; set; }
        public int ArtisansCount { get; set; }
    }
}
