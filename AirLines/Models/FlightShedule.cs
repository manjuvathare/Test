using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Models
{
    public class FlightShedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public int AirLineId { get; set; }
        public AirLine AirLine { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string TotalTime { get; set; }
        public float Price { get; set; }
    }
}
