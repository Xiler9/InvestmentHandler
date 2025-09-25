using InvestmentHandler.Enumerators;
using InvestmentHandler.Models;
using System.Text;

namespace InvestmentHandler.Services
{
    /// <summary>
    /// Service for Translating To HTML or XML
    /// </summary>
    public class DailyMarketDataHtmlStatisticsServcice : IDailyMarketDataHtmlStatisticsServcice
    {
        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas, DataFormatOptions dataFormatOptions)
        {
            StringBuilder stringBuilder = new StringBuilder();
            /// <summary>
            /// Translate into HTML
            /// </summary>
            if (dataFormatOptions == DataFormatOptions.HTML)
            {
                stringBuilder.AppendLine("<table>");
                stringBuilder.AppendLine("\t<thead>");
                stringBuilder.AppendLine("\t\t<tr>");
                stringBuilder.AppendLine("\t\t\t<th>Инструмент</th>");
                stringBuilder.AppendLine("\t\t\t<th>Дата</th>");
                stringBuilder.AppendLine("\t\t\t<th>Изменение цены</th>");
                stringBuilder.AppendLine("\t\t</tr>");
                stringBuilder.AppendLine("\t</thead>");
                stringBuilder.AppendLine("\t<tbody>");
                foreach (var data in datas)
                {
                    stringBuilder.AppendLine("\t\t<tr>");
                    stringBuilder.AppendLine($"\t\t\t<td>{data.InstrumentCode}</td>");
                    stringBuilder.AppendLine($"\t\t\t<td>{data.Date:dd.MM.yyyy}</td>");
                    if (data.Price - 90 >= 0) 
                    {
                        stringBuilder.AppendLine($"\t\t\t<td>Цена за этот день выросла на {Math.Round(data.Price / 90 * 100)}% ({data.Price - 90}р.)(сегоднешнея стоимоть - 90р)</td>");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"\t\t\t<td>Цена за этот день упала на {100 - Math.Round(data.Price / 90 * 100)}% ({data.Price - 90}р.)(сегоднешнея стоимоть - 90р)</td>");
                    }
                    stringBuilder.AppendLine("\t\t</tr>");
                }
                stringBuilder.AppendLine("\t</tbody>");
                stringBuilder.AppendLine("</table>");
            }
            /// <summary>
            /// Translate into XML
            /// </summary>
            else
            {
                stringBuilder.AppendLine("<Items>");
                foreach (var data in datas)
                {
                    var changeSign = data.Price - 90 >= 0 ? "+" : "-";
                    stringBuilder.AppendLine("\t<Item>");
                    stringBuilder.AppendLine($"\t\t<instrument>{data.InstrumentCode}</instrument>");
                    stringBuilder.AppendLine($"\t\t<date>{data.Date:dd.MM.yyyy}</date>");
                    if (data.Price - 90 >= 0)
                    {
                        stringBuilder.AppendLine($"\t\t<change>{changeSign}{Math.Round(data.Price / 90 * 100)}%</change>");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"\t\t<change>{changeSign}{100 - Math.Round(data.Price / 90 * 100)}%</change>");
                    }
                    stringBuilder.AppendLine("\t</Item>");
                }
                stringBuilder.AppendLine("</Items>");
            }
            return stringBuilder.ToString();
        }
    }
}