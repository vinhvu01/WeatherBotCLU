using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherBotCLU.Model
{
    public class WeatherData
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("days")]
        public List<Days> Days { get; set; }

        public string Period { get; set; }

        public string BingMapApiKey { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }

    public class Days
    {
        [JsonProperty("datetime")]
        public string DateTime { get; set; }

        [JsonProperty("windgust")]
        public string Windgust { get; set; }

        [JsonProperty("windspeed")]
        public string WindSpeed { get; set; }

        [JsonProperty("winddir")]
        public string WindDir { get; set; }

        [JsonProperty("pr")]
        public string Pr { get; set; }

        [JsonProperty("tempmin")]
        public string TempMin { get; set; }

        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("tempmax")]
        public string TempMax { get; set; }

        [JsonProperty("feelslike")]
        public string FeelsLike { get; set; }

        [JsonProperty("feelslikemin")]
        public string FeelsLikeMin { get; set; }

        [JsonProperty("feelslikemax")]
        public string FeelsLikeMax { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("dew")]
        public string Dew { get; set; }

        [JsonProperty("precip")]
        public string PreCip { get; set; }

        [JsonProperty("precipprob")]
        public string PreCipProb { get; set; }

        [JsonProperty("precipcover")]
        public string PreCipCover { get; set; }

        [JsonProperty("preciptype")]
        public object PreCipType { get; set; }

        [JsonProperty("snow")]
        public string Snow { get; set; }

        [JsonProperty("snowdepth")]
        public string SnowDepth { get; set; }

        [JsonProperty("hours")]
        public List<Hours> Hours { get; set; }
    }

    public class Hours
    {
        [JsonProperty("datetime")]
        public string DateTime { get; set; }

        [JsonProperty("windgust")]
        public string Windgust { get; set; }

        [JsonProperty("windspeed")]
        public string WindSpeed { get; set; }

        [JsonProperty("winddir")]
        public string WindDir { get; set; }

        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("feelslike")]
        public string FeelsLike { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("dew")]
        public string Dew { get; set; }

        [JsonProperty("precip")]
        public string PreCip { get; set; }

        [JsonProperty("precipprob")]
        public string PreCipProb { get; set; }

        [JsonProperty("preciptype")]
        public object PreCipType { get; set; }

        [JsonProperty("snow")]
        public string Snow { get; set; }

        [JsonProperty("snowdepth")]
        public string SnowDepth { get; set; }

        [JsonProperty("cloudcover")]
        public string CloudCover { get; set; }

        [JsonProperty("solarradiation")]
        public string SolarRadiation { get; set; }

        [JsonProperty("solarenergy")]
        public string SolarEnergy { get; set; }

        [JsonProperty("uvindex")]
        public string UvIndex { get; set; }

        [JsonProperty("severerisk")]
        public string SevereRisk { get; set; }

        [JsonProperty("conditions")]
        public string Conditions { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("stations")]
        public object Stations { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}