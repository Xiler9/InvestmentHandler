using Application.Models.DTOs_for_requests;
using Domain.Models;

namespace Application.Interfaces
{
    /// <summary>
    /// Interaface for GenerateRandomService
    /// </summary>
    public interface IGenerateRandomDataService
    {
        public Task<List<DailyMarketData>> GenerateRandomData(List<DataMarketRequest> dataMarketRequests, CancellationToken cancellationToken);
    }
}