using AirLines.Interfaces;
using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Services
{
    public class LocationService : ILocationRepository
    {
        private readonly AirlineDbContext _context;

        public LocationService(AirlineDbContext context)
        {
            _context = context;
        }
        public int AddLocation(Location locationModel)
        {
            _context.Locations.Add(locationModel);
            _context.SaveChanges();
            return locationModel.Id;
        }

        public List<Location> GetLocationListByName(string name)
        {
            var locations = _context.Locations.Where(x=>x.Name.Contains(name)).ToList();
            return locations;
        }

        public List<Location> GetLocationList()
        {
            var locations = _context.Locations.ToList();
            return locations;
        }
    }
}
