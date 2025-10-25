using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add DI
builder.Services.AddScoped<IDailyMarketDataReportService, DailyMarketDataStatisticsHTMLService>();
builder.Services.AddScoped<IDailyMarketDataReportService, DailyMarketDataStatisticsXMLService>();
builder.Services.AddScoped<IIdentifyFormatOptionService, IdentifyFormatOptionService>();
builder.Services.AddSingleton<IDailyMarketDatasRepositorie, DailyMarketDatasRepositorie>();


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