using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Entities.JsonModels;
using Weather.Entities.Models;

namespace Weather.Client
{
    public interface IWeatherClient
    {
        [Get("/weather/temperature/{cityName}/{metric}")]
        Task<TemperatureModel> GetTemperature(string city, string metric);

        [Get("/weather/wind/{cityName}/{metric}")]
        Task<WindModel> GetWind(string city, string metric);

        [Get("/weather/{cityName}/future/{metric}")]
        Task<FuturesModel> GetFuture(string city, string metric);

        [Get("/weather/GetCities/{count}")]
        Task<Cities> GetCities(string cityName);

        [Get("/weather/GetCity/{cityName}")]
        Task<IEnumerable<Cities>> GetCities(int count);
    }
}
