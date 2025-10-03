using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// interface for DailyMarketDataReportManagerService
    /// </summary>
    public interface IDailyMarketDataReportManagerService
    {
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOptions);
    }
}