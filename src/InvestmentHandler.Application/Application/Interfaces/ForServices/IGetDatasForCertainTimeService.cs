using Application.DTOs.Requests;
using Application.DTOs_for_requests;
using Domain.Models;

namespace Application.Interfaces.ForServices
{
    public interface IGetDatasForCertainTimeService
    {
        public List<DailyMarketData> GetDatasForCertainTime(GetMarketDataPricesForCertainTimeAsyncRequest getMarketDataPricesForCertainTimeRequest);
        public List<DailyMarketData> GetDatasForCertainTime(GetDataMarketPricesAsyncRequest getDataMarketPricesAsyncRequest);
    }
}