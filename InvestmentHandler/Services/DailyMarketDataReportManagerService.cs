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
        private List<IDailyMarketDataReportService> _dailyMarketDataReportServices = new List<IDailyMarketDataReportService>();

        public DailyMarketDataReportManagerService(IEnumerable<IDailyMarketDataReportService> dailyMarketDataReportServices)
        {
            _dailyMarketDataReportServices.AddRange(dailyMarketDataReportServices);
        }


        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOptions) => 
            _dailyMarketDataReportServices.Find(x => x.FormatOptions == dataFormatOptions).GetDailyMarketDataPriceChangeStatistics(datas);
    }
}