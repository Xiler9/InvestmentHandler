using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;
using System.Text;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Service for Translating To HTML or XML
    /// </summary>
    public class DailyMarketDataReportManagerService : IDailyMarketDataReportManagerService
    {
        //Список доступных форматов
        private List<IDailyMarketDataReportService> _dailyMarketDataReportServices = new List<IDailyMarketDataReportService>();

        public DailyMarketDataReportManagerService(IEnumerable<IDailyMarketDataReportService> dailyMarketDataReportServices)
        {
            _dailyMarketDataReportServices.AddRange(dailyMarketDataReportServices);
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