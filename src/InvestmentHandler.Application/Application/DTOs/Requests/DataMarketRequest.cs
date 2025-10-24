namespace Application.Models.DTOs_for_requests
{
    /// <summary>
    /// Element getting datas
    /// </summary>
    public record DataMarketRequest
    {
        public string InstrumentCode { get; init; } = null!;
        public int DaysCount { get; init; }
    }
}