using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Service for Translating To HTML or XML
    /// </summary>
    public class DailyMarketDataHtmlStatisticsServcice : IDailyMarketDataHtmlStatisticsServcice
    {
        /// <summary>
        /// Translate into HTML
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOptions)
        {
            if (dataFormatOptions == DataFormatOptions.HTML)
            {
                string result = @"
<table>
    <thead>
        <tr>
            <th>Инструмент</th>
            <th>Дата</th>
            <th>Изменение цены</th>
        </tr>
    </thead>
    <tbody>";
                foreach (var data in datas)
                {
                    result += $@"
        <tr>
            <td>{data.InstrumentCode}</td>
            <td>{data.Date:dd.MM.yyyy}</td>
            <td>Цена за этот день выросла/упала на {data.Price / 90 * 100} ({data.Price - 90}р.)(сегоднешнея стоимоть - 90р)</td>
        </tr>";
                }
                result += @"
    </tbody>
</table>";
                return result;
            }
            else
            {
                string result = @"
<Items>";
                foreach (var data in datas)
                {
                    result += $@"
    <Item>
        <instrument>{data.InstrumentCode}</instrument>
        <date>{data.Date:dd.MM.yyyy}</date>
        <change>{data.Price / 90 * 100 - 100:+0.0%}</change>
    </Item>";
                }
                result += @"
</Items>";
                return result;
            }
        }
    }
}