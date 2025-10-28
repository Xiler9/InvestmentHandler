using Domain.Models;

namespace Application.Interfaces.ForRepositories
{
    public interface IDailyMarketDatasRepositorie
    {
        public List<DailyMarketData> DailyMarketDatas { get; set; }
    }
}