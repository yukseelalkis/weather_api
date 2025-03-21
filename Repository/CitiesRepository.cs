using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherApi.Config;
using WeatherApi.Dto;
using WeatherApi.Interface;
using WeatherApi.Mappers;
using WeatherApi.model.City;

namespace WeatherApi.Repository
{
    public class CitiesRepository :ICityService
    {
        private readonly HttpClient _httpClient;
        private readonly CitiesConfig _citiesCongig;

        public CitiesRepository(HttpClient httpClient, IOptions<CitiesConfig> config)
        {
            _httpClient = httpClient;
            _citiesCongig = config.Value;
        }

       public async Task<List<CitiesDto>> getCities()
        {
            try
            {
                Console.WriteLine($"Base Urlm {_citiesCongig.BaseUrl}");
                var response = await _httpClient.GetAsync(_citiesCongig.BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    var cities = apiResponse.Data;

                    if (cities != null)
                    {
                        return cities.toCitiesDto();
                    }
                    else
                    {
                        Console.WriteLine($"API Response Null Data");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return new List<CitiesDto>();
        }
    }
}