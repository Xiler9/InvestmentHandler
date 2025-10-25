using Application.Models.DTOs_for_requests;

namespace Application.DTOs_for_requests
{
    /// <summary>
    /// Record for getting data from server
    /// </summary>
    public record GetDataMarketPricesAsyncRequest
    {
        public List<DataMarketRequest> dataMarketRequests { get; init; } = new List<DataMarketRequest>();
    }
}