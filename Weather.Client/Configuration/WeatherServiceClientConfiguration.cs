using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.Client.Configuration
{
    public static class WeatherServiceClientConfiguration
    {
        //Работа без авторизации
        public static IServiceCollection AddWeatherServiceClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddTransient(_ => RestService.For<IWeatherClient>(
                new HttpClient
                (
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true }
                )
                {
                    BaseAddress = new Uri(configuration["ServiceUrls:WeatherService"]),
                    Timeout = TimeSpan.FromMinutes(5)
                }));

            return services;
        }

        ////Работа с токеном
        //public static IServiceCollection AddWeatherServiceTokenClient(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddApiClient<IWeatherClient>(configuration, new RefitSettings(), "ServiceUrls:WeatherService");

        //    return services;
        //}

        ////Получение токена из appsettings
        //public static IServiceCollection AddWeatherServiceGetTokenClient(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var refitSettings = new RefitSettings
        //    {
        //        AuthorizationHeaderValueGetter = () => Task.FromResult(configuration["Token"])
        //    };
        //    services.AddApiClient<IWeatherClient>(configuration, refitSettings, "ServiceUrls:WeatherService");

        //    return services;
        //}
    }
}
