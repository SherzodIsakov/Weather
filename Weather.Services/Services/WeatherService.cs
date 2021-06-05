using AutoMapper;
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

        private readonly IMapper _mapper;
        public WeatherService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<TemperatureModel> GetTemperatureAsync(string city)
        {
            string urlOrig = Helper.GetTemperatureFromCitynameUrl;
            string urlRequest = urlOrig.Replace("CITYNAME", city).Replace("TOKEN", token);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                var jsonContent = await response.Content?.ReadAsStringAsync();
                var temperature = JsonConvert.DeserializeObject<WeatherEntity>(jsonContent);

                var iemperatureModel = _mapper.Map<TemperatureModel>(temperature);
                return iemperatureModel;
            }
        }
        public async Task<WindModel> GetWindAsync(string city)
        {
            string urlOrig = Helper.GetTemperatureFromCitynameUrl;
            string urlRequest = urlOrig.Replace("CITYNAME", city).Replace("TOKEN", token);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                var jsonContent = await response.Content?.ReadAsStringAsync();
                var temperature = JsonConvert.DeserializeObject<WeatherEntity>(jsonContent);

                var iemperatureModel = _mapper.Map<WindModel>(temperature);
                iemperatureModel.Direction = Helper.Direction(temperature.wind.Deg);
                return iemperatureModel;
            }
        }
        public async Task<FuturesModel> GetFutureAsync(string city)
        {
            string urlOrig = Helper.GetFutureFromCityNameUrl;
            string urlRequest = urlOrig.Replace("CITYNAME", city).Replace("TOKEN", token);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                var jsonContent = await response.Content?.ReadAsStringAsync();

                var futures = JsonConvert.DeserializeObject<Futures>(jsonContent);
                var iemperatureModel = _mapper.Map<FuturesModel>(futures);
                return iemperatureModel;
            }
        }
    }
}
