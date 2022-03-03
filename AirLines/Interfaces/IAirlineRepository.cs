using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Interfaces
{
    public interface IAirlineRepository
    {
        List<AirLine> GetAllAirlines();
        AirLine GetAirlineById(int id);
        AirLine UpdateAirline(AirLine airline);
        AirLine AddAirline(AirLine airline);
        void DeleteAirline(int id);
        AirLine GetAirlineByName(string name);
    }
}
