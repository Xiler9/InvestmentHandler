using Application.DTOs.Requests;
using Application.DTOs_for_requests;
using Application.Interfaces;
using Domain.Enumerators;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    /// <summary>
    /// Controller for getting datas about instruments
    /// </summary>
    public class MarketDataReportController : ControllerBase
    {
        private readonly IGetDatasForCertainTimeService _getDatasForCertainTimeService;
        private readonly IIdentifyFormatOptionService _identifyFormatOptionService;

        private readonly ILogger<MarketDataReportController> _logger;

        public MarketDataReportController(
            IGetDatasForCertainTimeService getDatasForCertainTimeService,
            IIdentifyFormatOptionService identifyFormatOptionService,
            ILogger<MarketDataReportController> logger)
        {
            _getDatasForCertainTimeService = getDatasForCertainTimeService;
            _identifyFormatOptionService = identifyFormatOptionService;
            _logger = logger;
        }

        /// <summary>
        /// Get information about instrument for certain time
        /// </summary>
        /// <param name="getDataMarketPricesRequest"> Request params </param>
        /// <param name="dataFormatOption"> Format option (HTML, JSON, etc) </param>
        /// <param name="cancellationToken"> Cancellation token from client </param>
        /// <returns> Returns report </returns>
        [HttpPost("GetDataMarketPricesAsync")]
        public async Task<IActionResult> GetMarketDataPricesAsync(
            [FromBody] GetDataMarketPricesAsyncRequest getDataMarketPricesAsyncRequest,
            [FromQuery] DataFormatOptions dataFormatOption,
            CancellationToken cancellationToken)
        {
            try
            {
                List<DailyMarketData> datas = _getDatasForCertainTimeService.GetDatasForCertainTime(
                getDataMarketPricesAsyncRequest); //получаешь даты
                string response = _identifyFormatOptionService
                    .GetDailyMarketDataPriceChangeStatistics(datas, dataFormatOption);
                return Ok(response);
                }
            catch (OperationCanceledException)
            {
                return StatusCode(499, "Клиент отменил запрос.");
            }
        }

        /// <summary>
        /// Get information about instrument for every month 20 past years time
        /// </summary>
        /// <param name="getDataMarketPricesRequest"> Request params </param>
        /// <returns> Returns report </returns>
        [HttpPost("GetMarketDataPricesForCertainTimeAsync")]
        public async Task<IActionResult> GetMarketDataPricesForCertainTimeAsync(
            [FromBody] GetMarketDataPricesForCertainTimeAsyncRequest getMarketDataPricesForCertainTimeAsyncRequest)
        {
            List<DailyMarketData> datas = _getDatasForCertainTimeService.GetDatasForCertainTime(
                getMarketDataPricesForCertainTimeAsyncRequest);
            return Ok(datas);
        }
    }
}