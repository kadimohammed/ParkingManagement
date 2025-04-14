using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Interfaces;

namespace ParkingManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {

        private readonly IStatisticsService _statisticsService;

        public AnalyticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalytics()
        {
            AnalyticsDTO statistics = await _statisticsService.GetTotalsAsync();
            return Ok(statistics);
        }

    }
}
