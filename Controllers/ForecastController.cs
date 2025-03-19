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
    public class ForecastController : ControllerBase
    {
        private readonly IForecastService _foreCastService;

        public ForecastController(IForecastService forecastService)
        {
            _foreCastService =forecastService;
        }
        
        [HttpGet("{city}")]
        public async Task<IActionResult> getForecast([FromRoute]string city)
        {
            var forecast = await _foreCastService.Get7DaysForecast(city); 
            if (forecast == null)
                {
                    return NotFound();
                }
            return Ok(forecast);
        }

    }
}