namespace InvestmentHandler.Models
{
    /// <summary>
    /// Record for getting data from server
    /// </summary>
    public record GetDataMarketPricesRequest
    {
        public List<DataMarketRequest> dataMarketRequests { get; init; } = new List<DataMarketRequest>();
    }
}