using Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs_for_requests;

namespace Api
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

        private readonly ILogger<MarketDataReportController> _logger;

        public MarketDataReportController(
            IGenerateRandomDataService randomDataService,
            IDailyMarketDataReportManagerService dailyMarketDataHtmlStatisticsServcice,
            ILogger<MarketDataReportController> logger)
        {
            _randomDataService = randomDataService;
            _dailyMarketDataHtmlStatisticsServcice = dailyMarketDataHtmlStatisticsServcice;
            _logger = logger;
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