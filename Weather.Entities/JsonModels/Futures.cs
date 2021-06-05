using Newtonsoft.Json;
using System.Collections.Generic;

namespace Weather.Entities.JsonModels
{
    public class Futures
    {
        [JsonProperty("list")]
        public List<Future> Future { get; set; }
    }
    public class Future
    {
        [JsonProperty("dt_txt")]
        public string Date { get; set; }

        [JsonProperty("main")]
        public MainTemp MainTemp { get; set; }
    }

}
