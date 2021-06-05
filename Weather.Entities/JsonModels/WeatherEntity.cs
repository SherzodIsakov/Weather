using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities.JsonModels
{
    public class WeatherEntity
    {
        [JsonProperty("coord")]
        public Coords coord { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
       
        [JsonProperty("main")]
        public MainTemp mainTemp { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("sys")]
        public Sys sys { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }

    }
    public class Coords
    {
        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }
    }
    public class Weather
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }
    }
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

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("sea_level")]
        public string Sea_level { get; set; }

        [JsonProperty("grnd_level")]
        public string Grnd_level { get; set; }

        [JsonProperty("temp_kf")]
        public string Temp_kf { get; set; }

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
    public class Clouds
    {
        [JsonProperty("all")]
        public string All { get; set; }
    }
    public class Sys
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}
