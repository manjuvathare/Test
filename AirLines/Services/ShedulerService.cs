using AirLines.Interfaces;
using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Services
{
    public class ShedulerService : IShedulerRepository
    {
        private readonly AirlineDbContext _context;

        public ShedulerService(AirlineDbContext context)
        {
            _context = context;
        }
        public FlightShedule GetFlightById(int id)
        {
            return _context.FlightShedule.FirstOrDefault(x=>x.Id==id);
        }

        public List<FlightShedule> GetFlightList(InputModel inputModel)
        {            
            return _context.FlightShedule.ToList();
        }

        public int SheduleFlight(FlightShedule flightShedule)
        {
            _context.FlightShedule.Add(flightShedule);
            _context.SaveChanges();
            return flightShedule.Id;
        }

        public int UpdateSheduleFlight(FlightShedule flightShedule)
        {
            _context.FlightShedule.Update(flightShedule);
            _context.SaveChanges();
            return flightShedule.Id;
        }
    }
}
