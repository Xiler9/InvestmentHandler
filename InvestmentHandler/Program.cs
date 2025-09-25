using InvestmentHandler.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

/// <summary>
/// Implement DI
/// </summary>
builder.Services.AddSingleton<IGenerateRandomDataService, GenerateRandomDataService>();
builder.Services.AddSingleton<IDailyMarketDataHtmlStatisticsServcice, DailyMarketDataHtmlStatisticsServcice>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();