using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities.Models
{
    public class FuturesModel
    {       
        public string City { get; set; }       
        public string Metric { get; set; } = "celsius";
        public List<FutureModel> FutureModel { get; set; }
    }

    public class FutureModel
    {
        public string Date { get; set; } = DateTime.Now.ToString();
        public string Temperature { get; set; }
        public string City { get; set; }
        public string Metric { get; set; } = "celsius";
    }
}
