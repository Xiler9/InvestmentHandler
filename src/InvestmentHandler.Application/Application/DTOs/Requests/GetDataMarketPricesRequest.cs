using Application.Models.DTOs_for_requests;

namespace Application.DTOs_for_requests
{
    /// <summary>
    /// Record for getting data from server
    /// </summary>
    public record GetDataMarketPricesRequest
    {
        public List<DataMarketRequest> dataMarketRequests { get; init; } = new List<DataMarketRequest>();
    }
}