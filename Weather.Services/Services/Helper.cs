using System;
using System.Collections.Generic;

namespace Weather.Services.Services
{
    public static class Helper
    {
        public const string GetTemperatureFromCitynameUrl = "https://api.openweathermap.org/data/2.5/weather?q=CITYNAME&units=METRIC&appid=TOKEN";
        public const string GetFutureFromCityNameUrl = "https://api.openweathermap.org/data/2.5/forecast?q=CITYNAME&units=METRIC&appid=TOKEN";
        public const string GetWindFromCityNameUrl = "https://api.openweathermap.org/data/2.5/weather?q=CITYNAME&units=METRIC&appid=TOKEN";

        public static Dictionary<string, string> Metrics
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "celsius", "metric" },
                    { "fahrenheit", "imperial" },
                    { "kelvin", "kelvin" }
                };
            }
        }
        public static string Direction(string degree)
        {
            var deg = Convert.ToDouble(degree);
            string[] caridnals = {
                "North (N)",
                "NorthNorthEast (NNE)",
                "NorthEast (NE)",
                "EastNorthEast (ENE)",
                "East (E)",
                "EastSouthEast (ESE)",
                "SouthEast (SE)",
                "SouthSouthEast (SSE)",
                "South (S)",
                "SouthSouthWest (SSW)",
                "SouthWest (SW)",
                "WestSouthWest (WSW)",
                "West (W)",
                "WestNorthWest (WNW)",
                "NorthWest (NW)",
                "NorthNorthWest (NNW)",
                "North (N)" };

            return caridnals[(int)Math.Round(((double)deg * 10 % 3600) / 225)];

        }
    }
}
