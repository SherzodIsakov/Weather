using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities.Models
{
    public class WindModel
    {
        public string City { get; set; }
        public string Speed { get; set; }
        public string Direction { get; set; }
        public string Metric { get; set; }
    }
}
