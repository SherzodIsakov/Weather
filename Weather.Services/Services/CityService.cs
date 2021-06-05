using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Weather.Entities.JsonModels;
using Weather.Services.Interfaces;

namespace Weather.Services.Services
{
    public class CityService : ICityService
    {
        static string path = @"Files/city.list.json";

        public async Task<IEnumerable<Cities>> GetCitiesAsync()
        {
            if (File.Exists(path))
            {
                var jsonContent = await File.ReadAllTextAsync(path);

                var result = JsonConvert.DeserializeObject<IEnumerable<Cities>>(jsonContent);

                return result;
            }

            return null;
        }
        public async Task<Cities> GetCityAsync(string cityName)
        {
            var cities = await GetCitiesAsync();

            if (cities?.Count() > 0)
            {
                return cities.FirstOrDefault(x => x.Name == cityName);
            }

            return null;
        }
        public async Task<IEnumerable<Cities>> GetCitiesAsync(int count)
        {
            var cities = await GetCitiesAsync();

            if (cities?.Count() > 0)
            {
                return cities.Take(count);
            }

            return null;
        }
    }
}
