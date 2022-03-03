using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public string PRNNo { get; set; }
        public FlightShedule FlightShedule { get; set; }
        public int FlightSheduleId { get; set; }
        public int? ReturnFlightSheduleId { get; set; }
        public int BookingStatusId { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
