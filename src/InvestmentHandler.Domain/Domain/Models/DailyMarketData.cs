namespace Domain.Models
{
    /// <summary>
    /// Instrument Data
    /// </summary>
    public class DailyMarketData
    {
        public string InstrumentCode { get; init; }
        public DateTime Date { get; init; }
        public decimal Price { get; init; }

        public DailyMarketData(string instrumentCode, DateTime date, decimal price)
        {
            InstrumentCode = instrumentCode;
            Date = date;
            Price = price;
        }
    }
}