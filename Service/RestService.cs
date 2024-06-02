using System;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherBotCLU.Model;

namespace WeatherBotCLU.Service
{
    public class RestService
    {
        HttpClient _client;
        

        public RestService()
        {
            _client = new HttpClient();

        }

        public WeatherData GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = _client.GetAsync(query).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var jsonSerializerOptions = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    };

                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return weatherData;
        }
    }
}
