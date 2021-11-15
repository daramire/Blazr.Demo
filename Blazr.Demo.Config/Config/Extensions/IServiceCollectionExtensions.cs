﻿/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

using Blazr.Demo.Core;
using Blazr.Demo.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Blazr.Demo.Config
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAppBlazorServerServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastDataStore>();
            services.AddSingleton<IWeatherForecastDataBroker, WeatherForecastServerDataBroker>();
            services.AddScoped<WeatherForecastViewService>();
        }

        public static void AddAppBlazorWASMServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastDataBroker, WeatherForecastAPIDataBroker>();
            services.AddScoped<WeatherForecastViewService>();
        }

        public static void AddAppWASMServerServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastDataStore>();
            services.AddSingleton<IWeatherForecastDataBroker, WeatherForecastServerDataBroker>();
        }
    }
}