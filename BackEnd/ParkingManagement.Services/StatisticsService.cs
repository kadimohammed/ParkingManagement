using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Interfaces;

namespace ParkingManagement.Services
{
    public class StatisticsService : IStatisticsService 
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }


        public async Task<AnalyticsDTO> GetTotalsAsync()
        {
            AnalyticsDTO analyticsData = new AnalyticsDTO
            {
                ParkingsCount = await _statisticsRepository.GetTotalParkingsAsync(),
                ClientsCount = await _statisticsRepository.GetTotalClientsAsync(),
                ArtisansCount = await _statisticsRepository.GetTotalArtisanAsync()
            };
            return analyticsData;
        }
    }
}
