using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Interfaces
{
    public interface IBookingDetailRepository
    {
         int BookFlight(BookingDetails bookingDetails);
         BookingDetails GetBookingDetailsByPRNNo(string prnNo);
         int UpdateBookingDetails(BookingDetails bookingDetails);
        List<BookingDetails> GetBookingDetails();

    }
}
