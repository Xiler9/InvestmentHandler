using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{

    /// <summary>
    /// Service for Generating Random Data Services
    /// </summary>
    public class GenerateRandomDataService : IGenerateRandomDataService
    {
        /// <summary>
        /// Generate Random data, current price stay between 1 and 200 
        /// </summary>
        /// <param name="dataMarketRequests"></param>
        /// <returns></returns>
        public async Task<List<DailyMarketData>> GenerateRandomData(List<DataMarketRequest> dataMarketRequests)
        {
            List<DailyMarketData> dailyMarketDatas = new List<DailyMarketData>();
            int randomPrice = 0;
            Random random = new Random();
            for (int i = 0;  i < dataMarketRequests.Count; i++)
            {
                //Calcell Token
                await Task.Delay(1000);
                for (int j = 0; j < dataMarketRequests[i].DaysCount; j++)
                {
                    randomPrice = random.Next(1, 200);
                    dailyMarketDatas.Add(new DailyMarketData
                    (
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