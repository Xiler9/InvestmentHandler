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
        private readonly IGenerateRandomDataService _randomDataService;
        private readonly IDailyMarketDataReportManagerService _dailyMarketDataHtmlStatisticsServcice;

        public MarketDataReportController(
            IGenerateRandomDataService randomDataService,
            IDailyMarketDataReportManagerService dailyMarketDataHtmlStatisticsServcice)
        {
            _randomDataService = randomDataService;
            _dailyMarketDataHtmlStatisticsServcice = dailyMarketDataHtmlStatisticsServcice;
        }

        /// <summary>
        /// Get information about instrument
        /// </summary>
        /// <param name="getDataMarketPricesRequest"> Request params </param>
        /// <param name="dataFormatOption"> Format option (HTML, JSON, etc) </param>
        /// <param name="cancellationToken"> Cancellation token from client </param>
        /// <returns> Returns report </returns>
        [HttpPost("GetDataMarketPricesAsync")]
        public async Task<IActionResult> GetMarketDataPricesAsync(
            [FromBody] GetDataMarketPricesRequest getDataMarketPricesRequest,
            [FromQuery] DataFormatOptions dataFormatOption,
            CancellationToken cancellationToken)
        {
            try
            {
                // Generate data with cancellation support
                var dailyMarketDatas = await _randomDataService.GenerateRandomData(getDataMarketPricesRequest.dataMarketRequests, cancellationToken);

                // Return report
                return Ok(_dailyMarketDataHtmlStatisticsServcice.GetDailyMarketDataPriceChangeStatistics(dailyMarketDatas, dataFormatOption));
            }
            catch (OperationCanceledException)
            {
                return StatusCode(499, "Клиент отменил запрос.");
            }
        }
    }
}
