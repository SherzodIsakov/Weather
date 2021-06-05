using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities.Models
{
    public class TemperatureModel
    {
        public string Date { get; set; }
        public string City { get; set; }
        public string Temperature { get; set; }
        public string Metric { get; set; }
    }       
}
