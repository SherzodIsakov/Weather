using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Client.Configuration
{
    public class WeatherClientConfiguration
    {
        public static IServiceCollection AddTaskServiceTokenClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiClient<ITaskClient>(configuration, new RefitSettings(), "ServiceUrls:TaskService");

            return services;
        }
    }
}
