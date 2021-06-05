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

        [HttpGet("temperature/{cityName}")]
        public async Task<ActionResult<TemperatureModel>> GetTemperature(string cityName)
        {
            try
            {
                var city = _cityService.GetCityAsync(cityName);
                if (city == null)
                {
                    return NotFound($"Город не найден");
                }

                var temp = await _weatherService.GetTemperatureAsync(cityName);
                return temp;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("wind/{cityName}")]
        public async Task<ActionResult<WindModel>> GetWind(string cityName)
        {
            try
            {
                var city = _cityService.GetCityAsync(cityName);
                if (city == null)
                {
                    return NotFound($"Город не найден");
                }

                var wind = await _weatherService.GetWindAsync(cityName);
                return wind;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{cityName}/future")]
        public async Task<ActionResult<FuturesModel>> GetFuture(string cityName)
        {
            try
            {
                var city = _cityService.GetCityAsync(cityName);
                if (city == null)
                {
                    return NotFound($"Город не найден");
                }

                var forecast = await _weatherService.GetFutureAsync(cityName);
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
