using Application.Interfaces.ForRepositories;
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
            var hoursCount = 365 * 24 * 20;

            var baseData = new List<DailyMarketData>
            {
                new("GAZP", DateTime.Now, 120),
                new("BTC", DateTime.Now, 9_663_000),
                new("USD", DateTime.Now, 91.1m)
            };

            DailyMarketDatas = new List<DailyMarketData>(hoursCount * baseData.Count);

            var dailyMaxPercentChange = 5;
            var random = new Random();

            foreach (var data in baseData)
            {
                var lastPrice = data.Price;
                var currentDateTime = DateTime.Now;

                for (int i = 0; i < hoursCount; i++)
                {
                    currentDateTime = RoundToHour(currentDateTime);

                    DailyMarketDatas.Add(new DailyMarketData(
                        data.InstrumentCode,
                        currentDateTime,
                        lastPrice
                    ));

                    var percentChange = random.Next(dailyMaxPercentChange * 2) - dailyMaxPercentChange;
                    lastPrice = Math.Round(lastPrice * (1m + percentChange / 100m), 2);

                    currentDateTime = currentDateTime.AddHours(-1);
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