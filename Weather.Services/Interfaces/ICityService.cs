using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Entities.JsonModels;

namespace Weather.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<Cities>> GetCitiesAsync();
        Task<Cities> GetCityAsync(string cityName);
        Task<IEnumerable<Cities>> GetCitiesAsync(int count);
    }
}
