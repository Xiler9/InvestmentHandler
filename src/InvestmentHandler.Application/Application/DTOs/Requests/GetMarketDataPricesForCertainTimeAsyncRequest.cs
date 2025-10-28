namespace Application.DTOs.Requests
{
    public record GetMarketDataPricesForCertainTimeAsyncRequest
    {
        public string InstrumentName { get; init; };
        public DateTime DateTime { get; init; }
    }
}