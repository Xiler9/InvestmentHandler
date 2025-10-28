using Application.Interfaces.ForServices;
using Domain.Enumerators;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    /// <summary>
    /// Service for Translating To HTML or XML
    /// </summary>
    public class IdentifyFormatOptionService : IIdentifyFormatOptionService
    {
        //Список доступных форматов
        private readonly List<IDailyMarketDataReportService> _dailyMarketDataReportServices = new List<IDailyMarketDataReportService>();

        private readonly ILogger<IdentifyFormatOptionService> _logger;

        public IdentifyFormatOptionService(IEnumerable<IDailyMarketDataReportService> dailyMarketDataReportServices, ILogger<IdentifyFormatOptionService> logger)
        {
            _dailyMarketDataReportServices.AddRange(dailyMarketDataReportServices);
            _logger = logger;
        }

        /// <summary>
        /// Fill information about instrument
        /// </summary>
        /// <param name="datas"> Generetaed datas </param>
        /// <param name="dataFormatOptions"> Text format </param>
        /// <returns></returns>
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOptions) =>
            _dailyMarketDataReportServices.Find(x => x.FormatOptions == dataFormatOptions).GetDailyMarketDataPriceChangeStatistics(datas);
    }
}