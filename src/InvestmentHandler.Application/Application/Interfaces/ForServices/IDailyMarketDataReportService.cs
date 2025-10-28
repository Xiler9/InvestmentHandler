using Domain.Enumerators;
using Domain.Models;

namespace Application.Interfaces.ForServices
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