using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Entities.Models;

namespace Weather.Services.Interfaces
{
    public interface IWeatherService
    {
        /// <summary>
        /// Возвращает текущую температуру в указанном городе в цельсиях и фаренгейтах
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="metric">Метрика (celsius|fahrenheit)</param>
        /// <returns></returns>
        Task<TemperatureModel> GetTemperatureAsync(string city);

        /// <summary>
        /// Возвращает текущее направление и скорость ветра в указанном городе 
        /// </summary>
        /// <param name="city">Город</param>
        /// <returns></returns>
        Task<WindModel> GetWindAsync(string city);

        /// <summary>
        /// Возвращает погоду на 5 дней вперед по указанному городу
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="metric">Метрика (celsius|fahrenheit)</param>
        /// <returns></returns>
        Task<FuturesModel> GetFutureAsync(string city);

    }
}
