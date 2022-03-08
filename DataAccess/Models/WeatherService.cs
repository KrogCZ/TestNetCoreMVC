using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class WeatherService
    {
        public WeatherService(IConfiguration configuration)
        {
            BaseUri = new Uri(configuration.GetSection("WeatherApi")["BaseURI"]);
            Url = configuration.GetSection("WeatherApi")["URL"];
            ApiKey = configuration.GetSection("WeatherApi")["APIKey"];
        }

        public Uri BaseUri { get; set; }
        public string Url { get; set; }

        public string ApiKey { get; set; }

        /// <summary>
        /// get weather by city name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>weather</returns>
        public WeatherModel GetWeatherByCity(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = BaseUri;
                    var response = client.GetAsync(Url.Replace("{APIKey}", ApiKey).Replace("{cityName}", name));
                    var stringResult = response.Result.Content.ReadAsStringAsync();
                    dynamic data = JObject.Parse(stringResult.Result);

                    var weather = new WeatherModel {
                        Temp = data.main.temp,
                        TempFeel = data.main.feels_like,
                        WeatherName = data.weather[0]["main"],
                        Wind = data.wind.speed,
                        Icon = $"http://openweathermap.org/img/wn/{data.weather[0]["icon"]}@2x.png"
                    };
                    return weather;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
