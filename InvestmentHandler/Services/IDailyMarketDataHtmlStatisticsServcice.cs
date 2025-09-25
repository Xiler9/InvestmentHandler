using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Interface for DailyMarketDataHtmlStatisticsServcice
    /// </summary>
    public interface IDailyMarketDataHtmlStatisticsServcice
    {
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOption);
    }
}