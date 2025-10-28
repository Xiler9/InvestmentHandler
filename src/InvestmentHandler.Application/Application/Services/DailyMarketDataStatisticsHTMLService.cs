using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Domain.Enumerators;
using Domain.Models;
using System.Text;

namespace Application.Services
{
    /// <summary>
    /// Get datas for HTML
    /// </summary>
    public class DailyMarketDataStatisticsHTMLService : IDailyMarketDataReportService
    {
        private readonly IDailyMarketDatasRepositorie _dailyMarketDatasRepositorie;

        public DataFormatOptions FormatOptions { get; set; } = DataFormatOptions.HTML;

        public DailyMarketDataStatisticsHTMLService(
            IDailyMarketDatasRepositorie dailyMarketDatasRepositorie)
        {
            _dailyMarketDatasRepositorie = dailyMarketDatasRepositorie;
        }

        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<table>");
            stringBuilder.AppendLine("\t<thead>");
            stringBuilder.AppendLine("\t\t<tr>");
            stringBuilder.AppendLine("\t\t\t<th>Инструмент</th>");
            stringBuilder.AppendLine("\t\t\t<th>Дата</th>");
            stringBuilder.AppendLine("\t\t\t<th>Изменение цены</th>");
            stringBuilder.AppendLine("\t\t</tr>");
            stringBuilder.AppendLine("\t</thead>");
            stringBuilder.AppendLine("\t<tbody>");
            stringBuilder.AppendLine("\t\t<tr>");

            //Fill first report from 27 to 44 line
            stringBuilder.AppendLine($"\t\t\t<td>{datas[^1].InstrumentCode}</td>");
            stringBuilder.AppendLine($"\t\t\t<td>{datas[^1].Date:dd.MM.yyyy}</td>");

            Random random = new Random();
            decimal randBase = random.Next(1, 100);

            if (datas[^1].Price - randBase > 0)
            {
                stringBuilder.AppendLine($"\t\t\t<td>Цена за прошлый день выросла на {Math.Round(((datas[^1].Price - randBase) / randBase) * 100, 2)}% (на {datas[^1].Price - randBase}р.)</td>");
            }
            else if (datas[^1].Price - randBase < 0)
            {
                stringBuilder.AppendLine($"\t\t\t<td>Цена за прошлый день упала на {Math.Round(((datas[^1].Price - randBase) / randBase) * 100, 2)}% (на {datas[^1].Price - randBase}р.)</td>");
            }
            else
            {
                stringBuilder.AppendLine("\t\t\t<td>Цена не изменилась</td>");
            }

            stringBuilder.AppendLine("\t\t</tr>");

            for (int i = 2; i < datas.Count + 1; i++)
            {
                stringBuilder.AppendLine("\t\t<tr>");
                stringBuilder.AppendLine($"\t\t\t<td>{datas[^i].InstrumentCode}</td>");
                stringBuilder.AppendLine($"\t\t\t<td>{datas[^i].Date:dd.MM.yyyy}</td>");

                //calculate changes
                if (datas[^i].Price - datas[^(i - 1)].Price > 0)
                {
                    stringBuilder.AppendLine($"\t\t\t<td>Цена за прошлый день выросла на {Math.Round(((datas[^i].Price - datas[^(i - 1)].Price) / datas[^(i - 1)].Price) * 100, 2)}% (на {datas[^i].Price - datas[^(i - 1)].Price}р.)</td>");
                }
                else if (datas[^i].Price - datas[^(i - 1)].Price < 0)
                {
                    stringBuilder.AppendLine($"\t\t\t<td>Цена за прошлый день упала на {Math.Round(((datas[^i].Price - datas[^(i - 1)].Price) / datas[^(i - 1)].Price) * 100, 2)}% (на {datas[^i].Price - datas[^(i - 1)].Price}р.)</td>");
                }
                else
                {
                    stringBuilder.AppendLine("\t\t\t<td>Цена не изменилась</td>");
                }

                stringBuilder.AppendLine("\t\t</tr>");
            }

            stringBuilder.AppendLine("\t</tbody>");
            stringBuilder.AppendLine("</table>");

            return stringBuilder.ToString();
        }
    }
}