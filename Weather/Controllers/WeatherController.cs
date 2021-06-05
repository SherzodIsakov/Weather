using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Entities.JsonModels;
using Weather.Entities.Models;
using Weather.Services.Interfaces;
using Weather.Services.Services;

namespace Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;
        private readonly ICityService _cityService;

        public WeatherController(
            ILogger<WeatherController> logger,
            IWeatherService weatherService,
            ICityService cityService)
        {
            _logger = logger;
            _weatherService = weatherService;
            _cityService = cityService;
        }

        [HttpGet("temperature/{cityName}/{metric}")]
        public async Task<ActionResult<TemperatureModel>> GetTemperature(string cityName, string metric)
        {
            try
            {
                if (!Helper.Metrics.ContainsKey(metric))
                {
                    return NotFound($"Не корректная метрика {metric}, допустимые метрики celsius, fahrenheit, kelvin");
                }

                var city = _cityService.GetCityAsync(cityName);
                if (city == null)
                {
                    return NotFound($"Город не найден");
                }

                string metricVal = Helper.Metrics[metric];
                var temp = await _weatherService.GetTemperatureAsync(cityName, metricVal);
                return temp;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("wind/{cityName}/{metric}")]
        public async Task<ActionResult<WindModel>> GetWind(string cityName, string metric)
        {
            try
            {
                if (!Helper.Metrics.ContainsKey(metric))
                {
                    return NotFound($"Не корректная метрика {metric}, допустимые метрики celsius, fahrenheit, kelvin");
                }

                var city = _cityService.GetCityAsync(cityName);
                if (city == null)
                {
                    return NotFound($"Город не найден");
                }

                string metricVal = Helper.Metrics[metric];
                var wind = await _weatherService.GetWindAsync(cityName, metricVal);
                return wind;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{cityName}/future/{metric}")]
        public async Task<ActionResult<IEnumerable<TemperatureModel>>> GetFuture(string cityName, string metric)
        {
            try
            {
                if (!Helper.Metrics.ContainsKey(metric))
                {
                    return NotFound($"Не корректная метрика {metric}, допустимые метрики celsius, fahrenheit, kelvin");
                }

                var city = _cityService.GetCityAsync(cityName);
                if (city == null)
                {
                    return NotFound($"Город не найден");
                }

                string metricVal = Helper.Metrics[metric];
                var forecast = await _weatherService.GetFutureAsync(cityName, metricVal);
                return Ok(forecast);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCities/{count}")]
        public async Task<IEnumerable<Cities>> GetCities(int count)
        {
            var city = await _cityService.GetCitiesAsync(count);
            return city.Take(count);
        }

        [HttpGet("GetCity/{cityName}")]
        public async Task<Cities> GetCities(string cityName)
        {
            var city = await _cityService.GetCityAsync(cityName);
            return city;
        }

    }
}
