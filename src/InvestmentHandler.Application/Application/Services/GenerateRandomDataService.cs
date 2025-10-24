using Application.Interfaces;
using Application.Models.DTOs_for_requests;
using Domain.Models;

namespace Application.Services
{
    /// <summary>
    /// Service for Generating Random Datas
    /// </summary>
    public class GenerateRandomDataService : IGenerateRandomDataService
    {
        /// <summary>
        /// Generate Random data
        /// </summary>
        /// <param name="dataMarketRequests"></param>
        /// <returns> Generated datas </returns>
        public async Task<List<DailyMarketData>> GenerateRandomData(List<DataMarketRequest> dataMarketRequests, CancellationToken cancellationToken)
        {
            List<DailyMarketData> dailyMarketDatas = new List<DailyMarketData>();
            int randomPrice = 0;
            Random random = new Random();

            for (int i = 0; i < dataMarketRequests.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Wait 10 seconds with support for cancellation
                await Task.Delay(10000, cancellationToken);

                for (int j = 0; j < dataMarketRequests[i].DaysCount; j++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    randomPrice = random.Next(1, 200);

                    dailyMarketDatas.Add(new DailyMarketData(
                        dataMarketRequests[i].InstrumentCode,
                        DateTime.Today.AddDays(-j),
                        randomPrice
                    ));
                }
            }

            return dailyMarketDatas;
        }
    }
}