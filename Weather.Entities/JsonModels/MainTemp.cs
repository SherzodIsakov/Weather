using Newtonsoft.Json;

namespace Weather.Entities.JsonModels
{
    public class MainTemp
    {
        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("feels_like")]
        public string Feels_like { get; set; }

        [JsonProperty("temp_min")]
        public string Temp_min { get; set; }

        [JsonProperty("temp_max")]
        public string Temp_max { get; set; }
    }
}
