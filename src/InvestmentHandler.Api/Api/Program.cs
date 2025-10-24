using Application.Interfaces;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add DI
builder.Services.AddSingleton<IGenerateRandomDataService, GenerateRandomDataService>();
builder.Services.AddSingleton<IDailyMarketDataReportService, DailyMarketDataStatisticsHTMLService>();
builder.Services.AddSingleton<IDailyMarketDataReportService, DailyMarketDataStatisticsXMLService>();
builder.Services.AddSingleton<IDailyMarketDataReportManagerService, DailyMarketDataReportManagerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();