using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Interface for DailyMarketDataHtmlStatisticsServcice
    /// </summary>
    public interface IDailyMarketDataReportService
    {
        public DataFormatOptions FormatOptions { get; set; }
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas);
    }
}