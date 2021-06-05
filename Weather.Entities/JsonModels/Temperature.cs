using Newtonsoft.Json;

namespace Weather.Entities.JsonModels
{
    public class Temperature
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("main")]
        public MainTemp MainTemp { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
    public class Wind
    {
        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("deg")]
        public string Deg { get; set; }

        [JsonProperty("gust")]
        public string Gust { get; set; }
    }
}
