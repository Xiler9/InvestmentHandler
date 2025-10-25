using Application.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class DailyMarketDatasRepositorie : IDailyMarketDatasRepositorie
    {
        public List<DailyMarketData> DailyMarketDatas { get; set; } = new List<DailyMarketData>();

        public DailyMarketDatasRepositorie()
        {
            CreateDailyMarketDatas();
        }

        private void CreateDailyMarketDatas()
        {
            var daysCount = 365 * 24 * 20;
            var todayData = new List<DailyMarketData>()
            {
                new("GAZP", DateTime.Today, 120),
                new("BTC", DateTime.Today, 9_663_000),
                new("USD", DateTime.Today, 91.1m)
            };

            var dailyData = new List<DailyMarketData>(daysCount * todayData.Count);
            var dailyMaxPercentChange = 5;

            var random = new Random();

            foreach (var data in todayData)
            {
                var lastPrice = data.Price;
                for (int i = 0; i < daysCount; i++)
                {
                    var currentDate = RoundToHour(DateTime.Today.AddDays(i));
                    dailyData.Add(new DailyMarketData(data.InstrumentCode, currentDate, lastPrice));

                    var percentChange = random.Next(dailyMaxPercentChange * 2) - dailyMaxPercentChange;
                    lastPrice = Math.Round(lastPrice * (1m + percentChange / 100m), 2);
                }
            }
        }

        private DateTime RoundToHour(DateTime date)
        {
            return new DateTime(
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                0,
                0);
        }
    }
}