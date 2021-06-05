using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Entities.JsonModels;
using Weather.Entities.Models;
using Weather.Services.Interfaces;

namespace Weather.Services.Services
{
    public class WeatherService : IWeatherService
    {
        string token = "2caaefdcafd242c8eae17b5f7dc6337a";

        public async Task<TemperatureModel> GetTemperatureAsync(string city, string metric)
        {
            string urlOrig = Helper.GetTemperatureFromCitynameUrl;
            string urlRequest = urlOrig.Replace("CITYNAME", city).Replace("METRIC", metric).Replace("TOKEN", token);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                var jsonContent = await response.Content?.ReadAsStringAsync();
                var temperature = JsonConvert.DeserializeObject<Temperature>(jsonContent);

                TemperatureModel temperatureModel = new TemperatureModel
                {
                    City = city,
                    Date = DateTime.Now.ToString(),
                    Metric = Helper.Metrics.FirstOrDefault(x => x.Value == metric).Key,
                    Temperature = temperature.MainTemp.Temp
                };

                return temperatureModel;
            }
        }
        public async Task<WindModel> GetWindAsync(string city, string metric)
        {
            string urlOrig = Helper.GetTemperatureFromCitynameUrl;
            string urlRequest = urlOrig.Replace("CITYNAME", city).Replace("METRIC", metric).Replace("TOKEN", token);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                var jsonContent = await response.Content?.ReadAsStringAsync();
                var temperature = JsonConvert.DeserializeObject<Temperature>(jsonContent);

                WindModel windModel = new WindModel
                {
                    City = city,
                    Speed = temperature.Wind.Speed,
                    Metric = Helper.Metrics.FirstOrDefault(x => x.Value == metric).Key,
                    Direction = Helper.Direction(temperature.Wind.Deg)
                };

                return windModel;
            }
        }
        public async Task<IEnumerable<TemperatureModel>> GetFutureAsync(string city, string metric)
        {
            string urlOrig = Helper.GetFutureFromCityNameUrl;
            string urlRequest = urlOrig.Replace("CITYNAME", city).Replace("METRIC", metric).Replace("TOKEN", token);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                var jsonContent = await response.Content?.ReadAsStringAsync();

                var futureModels = JsonConvert.DeserializeObject<Futures>(jsonContent);

                List<TemperatureModel> ForecastModels = new List<TemperatureModel>();
                foreach (var item in futureModels.Future)
                {
                    ForecastModels.Add(
                        new TemperatureModel
                        {
                            City = city,
                            Date = item.Date,
                            Metric = Helper.Metrics.FirstOrDefault(x => x.Value == metric).Key,
                            Temperature = item.MainTemp.Temp
                        });
                }

                return ForecastModels;
            }
        }
    }
}
