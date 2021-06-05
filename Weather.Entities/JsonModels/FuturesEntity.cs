using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Weather.Entities.JsonModels
{
    public class Futures
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnt")]
        public string Cnt { get; set; }

        [JsonProperty("list")]
        public List<FutureEntity> FutureEntity { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
    public class FutureEntity
    {
        [JsonProperty("dt")]
        public string Dt { get; set; }       

        [JsonProperty("main")]
        public MainTemp mainTemp { get; set; }
       
        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("pop")]
        public string Pop { get; set; }

        [JsonProperty("sys")]
        public Sys2 sys2 { get; set; }

        [JsonProperty("dt_txt")]
        public string Date { get; set; }
    }

    public class Sys2
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public class City
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("population")]
        public string Population { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }



}
