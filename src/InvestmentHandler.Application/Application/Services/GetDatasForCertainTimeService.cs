using Application.DTOs.Requests;
using Application.DTOs_for_requests;
using Application.Interfaces;
using Application.Models.DTOs_for_requests;
using Application.Repositories;
using Domain.Models;

namespace Application.Services
{
    public class GetDatasForCertainTimeService : IGetDatasForCertainTimeService
    {
        private readonly IDailyMarketDatasRepositorie _dailyMarketDatasRepositorie;

        public GetDatasForCertainTimeService(IDailyMarketDatasRepositorie dailyMarketDatasRepositorie)
        {
            _dailyMarketDatasRepositorie = dailyMarketDatasRepositorie;
        }

        public List<DailyMarketData> GetDatasForCertainTime(
            GetMarketDataPricesForCertainTimeAsyncRequest getMarketDataPricesForCertainTimeRequest) => 
            _dailyMarketDatasRepositorie.DailyMarketDatas
            .Where(x => x.InstrumentCode == getMarketDataPricesForCertainTimeRequest.InstrumentName 
            && x.Date.Hour == getMarketDataPricesForCertainTimeRequest.dateTime.Hour 
            && x.Date.Day == 1)
            .ToList();

        public List<DailyMarketData> GetDatasForCertainTime(GetDataMarketPricesAsyncRequest getDataMarketPricesAsyncRequest)
        {
            List<DailyMarketData> response = new List<DailyMarketData>();
            int length = getDataMarketPricesAsyncRequest.dataMarketRequests.Count;
            List<DataMarketRequest> datas = getDataMarketPricesAsyncRequest.dataMarketRequests;

            for (int i = 0; i < length; i++)
            {
                response.AddRange(_dailyMarketDatasRepositorie.DailyMarketDatas
                    .Where(x => x.InstrumentCode == datas[i].InstrumentCode
                    && x.Date > DateTime.Today.AddDays(-datas[i].DaysCount)));
            }

            return response;
        }
    }
}