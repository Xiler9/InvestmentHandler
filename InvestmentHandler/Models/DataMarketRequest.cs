namespace InvestmentHandler.Models
{
    /// <summary>
    /// Element etting datas
    /// </summary>
    public record DataMarketRequest
    {
        public string InstrumentCode { get; init; }
        public int DaysCount { get; init; }
    }
}