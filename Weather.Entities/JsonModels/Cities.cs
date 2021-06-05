using Newtonsoft.Json;

namespace Weather.Entities.JsonModels
{
    /// <summary>
    /// список городов из файла json для проверки корректности имени города
    /// </summary>
    public class Cities
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }
    }
    public class Coord
    {
        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }
    }
}
