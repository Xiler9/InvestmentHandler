using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Application.Services;
using FluentValidation;
using Infrastructure.Repositories;

namespace Api.Extensions
{
    public static class DICollectionExtensions
    {
        public static IServiceCollection AddDICollection(this IServiceCollection services)
        {
            //Add DI to services

            services.AddScoped<IDailyMarketDataReportService, DailyMarketDataStatisticsHTMLService>();
            services.AddScoped<IDailyMarketDataReportService, DailyMarketDataStatisticsXMLService>();
            services.AddScoped<IGetDatasForCertainTimeService, GetDatasForCertainTimeService>();
            services.AddScoped<IIdentifyFormatOptionService, IdentifyFormatOptionService>();

            //Add DI to repositories

            services.AddSingleton<IDailyMarketDatasRepositorie, DailyMarketDatasRepositorie>();

            //Add DI to validators

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}