using System;
using System.Threading.Tasks;
using WeatherApi.Interface;
using WeatherApi.model;
using Newtonsoft.Json;
using WeatherApi.Dto;
using WeatherApi.Mappers;
using WeatherApi.Config;
using Microsoft.Extensions.Options;

namespace WeatherApi.Repository
{
    public class WeatherRepository : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherConfig _weatherConfig;

        public WeatherRepository(HttpClient httpClient, IOptions<OpenWeatherConfig> weatherConfig)
        {
            _httpClient = httpClient;
            _weatherConfig = weatherConfig.Value;
        }

        public async Task<WeatherDto> getWeather(string city)
        {
            try
            {
                // ✅ Config üzerinden BaseUrl ve ApiKey okuyoruz
                //var url = $"{_weatherConfig.BaseUrl}?q={city}&appid={_weatherConfig.ApiKey}";
                var weatherUrl = $"{_weatherConfig.BaseUrl}weather?q={city}&appid={_weatherConfig.ApiKey}";
                var response = await _httpClient.GetAsync(weatherUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherRes = JsonConvert.DeserializeObject<WeatherResponse>(content);
                    if (weatherRes != null)
                    {
                        return weatherRes.ToWeatherDto();
                    }
                }
                else
                {
                    Console.WriteLine($"API Response Failed. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return null;
        }
    }
}
