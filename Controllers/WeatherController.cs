using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Interface;

namespace WeatherApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService  _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService =weatherService;
        }
         // weather gettt///
        [HttpGet("{city}")]
        public async Task<IActionResult> getWeather([FromRoute]string city)
        {
            var weather = await  _weatherService.getWeather(city);
            if (weather == null)
            {
                return NotFound();
            }
            return Ok(weather);
        }

    }
}