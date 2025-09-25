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
    public class DataAcquisitionController : ControllerBase
    {
        /// <summary>
        /// Services
        /// </summary>
        private IGenerateRandomDataService _randomDataService;
        private IDailyMarketDataHtmlStatisticsServcice _dailyMarketDataHtmlStatisticsServcice;

        /// <summary>
        /// Implement DI
        /// </summary>
        /// <param name="randomDataService"></param>
        /// <param name="dailyMarketDataHtmlStatisticsServcice"></param>
        public DataAcquisitionController(IGenerateRandomDataService randomDataService, IDailyMarketDataHtmlStatisticsServcice dailyMarketDataHtmlStatisticsServcice)
        {
            _randomDataService = randomDataService;
            _dailyMarketDataHtmlStatisticsServcice = dailyMarketDataHtmlStatisticsServcice;
        }

        /// <summary>
        /// Get information about instrument
        /// </summary>
        /// <param name="getDataMarketPricesRequest"></param>
        /// <param name="_randomDataService"></param>
        /// <returns></returns>
        [HttpPost("GetDataMarketPricesAsync")]
        public async Task<IActionResult> GetDataMarketPricesAsync([FromBody] GetDataMarketPricesRequest getDataMarketPricesRequest, [FromQuery] DataFormatOptions dataFormatOption)
        {
            List<DailyMarketData> dailyMarketDatas = new List<DailyMarketData>();
            dailyMarketDatas = await _randomDataService.GenerateRandomData(getDataMarketPricesRequest.dataMarketRequests);
            return Ok(_dailyMarketDataHtmlStatisticsServcice.GetDailyMarketDataPriceChangeStatistics(dailyMarketDatas, dataFormatOption));
        }
    }
}