using AirLines.Interfaces;
using AirLines.Models;
using AirLines.Services;
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
    public class AirLineController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRpository;
        public AirLineController(IAirlineRepository airlineRpository)
        {
            _airlineRpository = airlineRpository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _airlineRpository.GetAllAirlines();
            return Ok(data);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var data = _airlineRpository.GetAirlineById(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(AirLine airline)
        {
            var data = _airlineRpository.GetAirlineByName(airline.Name);
            if (data != null)
                return BadRequest("Airline with name "+airline.Name+" already exist.");

            var air = _airlineRpository.AddAirline(airline);
            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host+"/"+air.Id,air);
        }

        [HttpPut]
        public IActionResult Put(AirLine airline)
        {
            var data = _airlineRpository.GetAirlineByName(airline.Name);
            if (data != null)
                return BadRequest("Airline with name " + airline.Name + " already exist.");

            var air = _airlineRpository.UpdateAirline(airline);
            return Ok(air);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _airlineRpository.DeleteAirline(id);
            
            return Ok("Deleted successfully");
        }
    }
}
