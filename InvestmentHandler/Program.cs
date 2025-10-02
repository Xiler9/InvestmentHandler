using InvestmentHandler.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

//Add DI
builder.Services.AddSingleton<IGenerateRandomDataService, GenerateRandomDataService>();
builder.Services.AddSingleton<IDailyMarketDataReportService, DailyMarketDataStatisticsHTMLService>();
builder.Services.AddSingleton<IDailyMarketDataReportService, DailyMarketDataStatisticsXMLService>();
builder.Services.AddSingleton<IDailyMarketDataReportManagerService, DailyMarketDataReportManagerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();