using AirLines.Interfaces;
using AirLines.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = _locationRepository.GetLocationList();
            return Ok(data);
        }

        [HttpGet]
        [Route("Name")]
        public IActionResult Get(string name)
        {
            var data = _locationRepository.GetLocationListByName(name);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(Location location)
        {
            var data = _locationRepository.AddLocation(location);
            

            return Ok(data);
        }
    }
}
