using AirLines.Interfaces;
using AirLines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Services
{
    public class BookingDetailService : IBookingDetailRepository
    {
        private readonly AirlineDbContext _contex;

        public BookingDetailService(AirlineDbContext contex)
        {
             _contex= contex;
        }
        public int BookFlight(BookingDetails bookingDetails)
        {
            _contex.BookingDetails.Add(bookingDetails);
            _contex.SaveChanges();
            return bookingDetails.Id;
        }        

        public BookingDetails GetBookingDetailsByPRNNo(string prnNo)
        {
            return _contex.BookingDetails.FirstOrDefault(x=>x.PRNNo==prnNo);
        }

        public List<BookingDetails> GetBookingDetails()
        {
            return _contex.BookingDetails.ToList();
        }
        public int UpdateBookingDetails(BookingDetails bookingDetails)
        {
            _contex.BookingDetails.Update(bookingDetails);
            _contex.SaveChanges();
            return bookingDetails.Id;
        }
    }
}
