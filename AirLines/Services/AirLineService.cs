using AirLines.Interfaces;
using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Services
{
    public class AirLineService : IAirlineRepository
    {
        private readonly AirlineDbContext _context;
        public AirLineService(AirlineDbContext context)
        { _context = context; }
        public AirLine AddAirline(AirLine airline)
        {
            _context.Airline.Add(airline);
            _context.SaveChanges();
            return airline;
        }

        public void DeleteAirline(int id)
        {
            AirLine air = GetAirlineById(id);
            _context.Airline.Remove(air);
            _context.SaveChanges();
        }

        public AirLine GetAirlineById(int id)
        {
            return _context.Airline.FirstOrDefault(x=>x.Id==id);
        }

        public AirLine GetAirlineByName(string name)
        {
            return _context.Airline.FirstOrDefault(x => x.Name.Equals(name));
        }        

        public List<AirLine> GetAllAirlines()
        {
            return _context.Airline.ToList();
        }

        public AirLine UpdateAirline(AirLine airline)
        {
            _context.Airline.Update(airline);
            _context.SaveChanges();
            return airline;
        }
    }
}
