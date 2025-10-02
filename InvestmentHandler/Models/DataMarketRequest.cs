namespace InvestmentHandler.Models
{
    /// <summary>
    /// Element etting datas
    /// </summary>
    public record DataMarketRequest
    {
        public string InstrumentCode { get; init; } = null!;
        public int DaysCount { get; init; }
    }
}