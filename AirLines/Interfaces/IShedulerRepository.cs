using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Interfaces
{
    public interface IShedulerRepository
    {
        int SheduleFlight(FlightShedule flightShedule);
        List<FlightShedule> GetFlightList(InputModel inputModel);
        FlightShedule GetFlightById(int id);
        int UpdateSheduleFlight(FlightShedule flightShedule);

    }
}
