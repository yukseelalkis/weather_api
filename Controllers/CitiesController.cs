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
    public class CitiesController :ControllerBase
    {
        private readonly ICityService _citiesService;

        public CitiesController(ICityService cityService)
        {
            _citiesService = cityService;
        }
    
        [HttpGet]
        public async Task<IActionResult> getCities()
        {
            var cities = await _citiesService.getCities();
            if (cities == null)
            {
                return NotFound("Problem vars");
            }
            return Ok(cities);
        }    
    }
}