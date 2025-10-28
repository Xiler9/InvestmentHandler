using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Domain.Enumerators;
using Domain.Models;
using System.Text;

namespace Application.Services
{
    /// <summary>
    /// Get datas for XML
    /// </summary>
    public class DailyMarketDataStatisticsXMLService : IDailyMarketDataReportService
    {
        private readonly IDailyMarketDatasRepositorie _dailyMarketDatasRepositorie;

        public DataFormatOptions FormatOptions { get; set; } = DataFormatOptions.XML;

        public DailyMarketDataStatisticsXMLService(IDailyMarketDatasRepositorie dailyMarketDatasRepositorie)
        {
            _dailyMarketDatasRepositorie = dailyMarketDatasRepositorie;
        }

        public string GetDailyMarketDataPriceChangeStatistics(List<DailyMarketData> datas)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<Items>");
            stringBuilder.AppendLine("\t<Item>");

            //Fill first report from 21 to 39 line
            stringBuilder.AppendLine($"\t\t<instrument>{datas[^1].InstrumentCode}</instrument>");
            stringBuilder.AppendLine($"\t\t<date>{datas[^1].Date:dd.MM.yyyy}</date>");

            Random random = new Random();
            decimal randBase = random.Next(1, 100);

            if (datas[^1].Price - randBase > 0)
            {
                stringBuilder.AppendLine($"\t\t<change>+{Math.Round(((datas[^1].Price - randBase) / randBase) * 100, 2)}%</change>");
            }
            else if (datas[^1].Price - randBase < 0)
            {
                stringBuilder.AppendLine($"\t\t<change>{Math.Round(((datas[^1].Price - randBase) / randBase) * 100, 2)}%</change>");
            }
            else
            {
                stringBuilder.AppendLine("\t\t<change>0%</change>");
            }

            stringBuilder.AppendLine("\t</Item>");

            for (int i = 2; i < datas.Count + 1; i++)
            {
                stringBuilder.AppendLine("\t<Item>");
                stringBuilder.AppendLine($"\t\t<instrument>{datas[^i].InstrumentCode}</instrument>");
                stringBuilder.AppendLine($"\t\t<date>{datas[^i].Date:dd.MM.yyyy}</date>");

                //calculate changes
                if (datas[^i].Price - datas[^(i - 1)].Price > 0)
                {
                    stringBuilder.AppendLine($"\t\t<change>+{Math.Round(((datas[^i].Price - datas[^(i - 1)].Price) / datas[^(i - 1)].Price) * 100, 2)}%</change>");
                }
                else if (datas[^i].Price - datas[^(i - 1)].Price < 0)
                {
                    stringBuilder.AppendLine($"\t\t<change>{Math.Round(((datas[^i].Price - datas[^(i - 1)].Price) / datas[^(i - 1)].Price) * 100, 2)}%</change>");
                }
                else
                {
                    stringBuilder.AppendLine("\t\t<change>0%</change>");
                }

                stringBuilder.AppendLine("\t</Item>");
            }

            stringBuilder.AppendLine("</Items>");

            return stringBuilder.ToString();
        }
    }
}