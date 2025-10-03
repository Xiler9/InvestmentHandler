using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Interface for every text format
    /// </summary>
    public interface IDailyMarketDataReportService
    {
        public DataFormatOptions FormatOptions { get; set; }
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas);
    }
}