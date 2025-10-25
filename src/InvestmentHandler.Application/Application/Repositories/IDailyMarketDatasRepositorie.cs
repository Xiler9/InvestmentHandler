using Domain.Models;

namespace Application.Repositories
{
    public interface IDailyMarketDatasRepositorie
    {
        public List<DailyMarketData> DailyMarketDatas { get; set; }
    }
}