using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Application.Services;
using Infrastructure.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add DI to services

builder.Services.AddScoped<IDailyMarketDataReportService, DailyMarketDataStatisticsHTMLService>();
builder.Services.AddScoped<IDailyMarketDataReportService, DailyMarketDataStatisticsXMLService>();
builder.Services.AddScoped<IGetDatasForCertainTimeService, GetDatasForCertainTimeService>();
builder.Services.AddScoped<IIdentifyFormatOptionService, IdentifyFormatOptionService>();

//Add DI to repositories

builder.Services.AddSingleton<IDailyMarketDatasRepositorie, DailyMarketDatasRepositorie>();

//Add DI to validators

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

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