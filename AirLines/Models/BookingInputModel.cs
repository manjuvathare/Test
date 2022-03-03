using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Models
{
    public class BookingInputModel
    {
        public BookingDetails BookingDetail { get; set; }
        public FlightShedule Travel { get; set; }
        public FlightShedule Return { get; set; }
    }
}
