using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;
using InvestmentHandler.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentHandler.Controllers
{
    [Route("api")]
    [ApiController]
    /// <summary>
    /// Controller for getting datas about instruments
    /// </summary>
    public class MarketDataReportController : ControllerBase
    {
        /// <summary>
        /// Services
        /// </summary>
        private readonly IGenerateRandomDataService _randomDataService;
        private readonly IDailyMarketDataReportManagerService _dailyMarketDataHtmlStatisticsServcice;

        /// <summary>
        /// Implement DI
        /// </summary>
        /// <param name="randomDataService"></param>
        /// <param name="dailyMarketDataHtmlStatisticsServcice"></param>
        public MarketDataReportController(IGenerateRandomDataService randomDataService, IDailyMarketDataReportManagerService dailyMarketDataHtmlStatisticsServcice)
        {
            _randomDataService = randomDataService;
            _dailyMarketDataHtmlStatisticsServcice = dailyMarketDataHtmlStatisticsServcice;
        }

        /// <summary>
        /// Get information about instrument
        /// </summary>
        /// <param name="getDataMarketPricesRequest"> Request params </param>
        /// <returns> Returns report </returns>
        [HttpPost("GetDataMarketPricesAsync")]
        public async Task<IActionResult> GetMarketDataPricesAsync([FromBody] GetDataMarketPricesRequest getDataMarketPricesRequest, [FromQuery] DataFormatOptions dataFormatOption)
        {
            var dailyMarketDatas = await _randomDataService.GenerateRandomData(getDataMarketPricesRequest.dataMarketRequests);
            return Ok(_dailyMarketDataHtmlStatisticsServcice.GetDailyMarketDataPriceChangeStatistics(dailyMarketDatas, dataFormatOption));
        }
    }
}