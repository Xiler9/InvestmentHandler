using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Interaface for GenerateRandomService
    /// </summary>
    public interface IGenerateRandomDataService
    {
        public Task<List<DailyMarketData>> GenerateRandomData(List<DataMarketRequest> dataMarketRequests);
    }
}