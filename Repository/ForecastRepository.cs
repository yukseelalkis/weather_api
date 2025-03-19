using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherApi.Config;
using WeatherApi.Dto;
using WeatherApi.Interface;
using WeatherApi.Mappers;
using WeatherApi.model.Forecast;

namespace WeatherApi.Repository
{
    public class ForecastRepository : IForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherConfig _weatherConfig;


        public ForecastRepository(HttpClient httpClient ,IOptions<OpenWeatherConfig> openWeatherConfig )
        {
            _httpClient= httpClient;
            _weatherConfig = openWeatherConfig.Value;
        }


        public async Task<List<ForecastDto>> Get7DaysForecast(string city)
        {
            try
            {
                var forecastUrl = $"{_weatherConfig.BaseUrl}forecast?q={city}&appid={_weatherConfig.ApiKey}";
                var response = await _httpClient.GetAsync(forecastUrl);
                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var forecasRes = JsonConvert.DeserializeObject<ForecastResponse>(content);
                        if(forecasRes != null)
                        {
                            return forecasRes.ToForecastDto();
                        }
                        else 
                        {
                            Console.WriteLine($"API Response Failed. Status Code: {response.StatusCode}");
                        }
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