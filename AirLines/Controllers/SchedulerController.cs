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
    public class SchedulerController : ControllerBase
    {
        private readonly IShedulerRepository _shedulerRepository;

        public SchedulerController(IShedulerRepository shedulerRepository)
        {
            _shedulerRepository = shedulerRepository;
        }

        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var data = _shedulerRepository.GetFlightById(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        [Route("/GetFlightList")]
        public IActionResult GetFlightList(InputModel inputModel)
        {
            if (inputModel.Type == 0)
            {
                var oneWayFlight = _shedulerRepository.GetFlightList(inputModel);
                oneWayFlight = oneWayFlight.Where(x => x.Date.ToString("MM/dd/yyyy") == inputModel.TravelDate.ToString("MM/dd/yyyy") && x.FromLocationId == inputModel.FromLocationId && x.ToLocationId == inputModel.ToLocationId).ToList();
                return Ok(new { oneWayFlight});
            }
            else
            {
               var data = _shedulerRepository.GetFlightList(inputModel);
               var  oneWayFlight = data.Where(x => x.Date.ToString("MM/dd/yyyy") == inputModel.TravelDate.ToString("MM/dd/yyyy") && x.FromLocationId == inputModel.FromLocationId && x.ToLocationId == inputModel.ToLocationId).ToList();
                

                var returnFlight = data.Where(x => x.Date.ToString("MM/dd/yyyy") == inputModel.ReturnDate.ToString("MM/dd/yyyy") && x.FromLocationId==inputModel.ToLocationId && x.ToLocationId==inputModel.ToLocationId).ToList();

                return Ok(new { oneWayFlight, returnFlight });
            }
        }


        [HttpPost]        
        public IActionResult Post(FlightShedule flightShedule)
        {
            var data = _shedulerRepository.SheduleFlight(flightShedule);
            return Ok(data);
        }
    }
}
