using Domain.Enumerators;
using Domain.Models;

namespace Application.Interfaces
{
    /// <summary>
    /// interface for DailyMarketDataReportManagerService
    /// </summary>
    public interface IDailyMarketDataReportManagerService
    {
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOptions);
    }
}