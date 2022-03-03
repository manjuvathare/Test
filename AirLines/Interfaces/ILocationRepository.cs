using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Interfaces
{
    public interface ILocationRepository
    {
       List<Location> GetLocationListByName(string Name);
        List<Location> GetLocationList();
        int AddLocation(Location locationModel);
    }
}
