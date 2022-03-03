using AirLines.Interfaces;
using AirLines.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IShedulerRepository _shedulerRepository;
        public BookingController(IBookingDetailRepository bookingDetailRepository, IShedulerRepository shedulerRepository)
        {
            _bookingDetailRepository = bookingDetailRepository;
            _shedulerRepository = shedulerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bookingDetails = _bookingDetailRepository.GetBookingDetails();
            return Ok(bookingDetails);
        }

        [HttpGet]
        [Route("prnno")]
        public IActionResult Get(string prnno)
        {
            var bookingDetail = _bookingDetailRepository.GetBookingDetailsByPRNNo(prnno);
            if (bookingDetail == null)
                return NotFound();
            else
            {
                BookingInputModel bookingData;
                FlightShedule travelData=_shedulerRepository.GetFlightById(bookingDetail.FlightSheduleId);
                
                FlightShedule returnData=new FlightShedule();
                if (bookingDetail.ReturnFlightSheduleId != 0)
                {
                    int returnId = (int)bookingDetail.ReturnFlightSheduleId;
                    returnData = _shedulerRepository.GetFlightById(returnId);
                }
                bookingData = new BookingInputModel { BookingDetail = bookingDetail ,Travel=travelData,Return=returnData};
                return Ok(bookingData);
            }            
        }

        [HttpPost]
        public IActionResult BookFlight(BookingDetails bookingDetails)
        {
            int id = _bookingDetailRepository.BookFlight(bookingDetails);
            return Ok(id);
        }

        [HttpPut]
        [Route("prnno")]
        public IActionResult CancleBooking(string prnno)
        {
            BookingDetails bookingDetails = _bookingDetailRepository.GetBookingDetailsByPRNNo(prnno);
            if (bookingDetails == null)
                return NotFound("Invalid PRN Number");

            bookingDetails.BookingStatusId = 3;
            int id = _bookingDetailRepository.UpdateBookingDetails(bookingDetails);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult UpdateBooking(BookingInputModel bookingInputModel)
        {
            BookingDetails bookingDetails = _bookingDetailRepository.GetBookingDetailsByPRNNo(bookingInputModel.BookingDetail.PRNNo);
            if (bookingDetails == null)
                return NotFound("Invalid PRN Number");

            _shedulerRepository.UpdateSheduleFlight(bookingInputModel.Travel);
            if(bookingInputModel.Return!=null)
            {
                _shedulerRepository.UpdateSheduleFlight(bookingInputModel.Return);
            }

            int id = _bookingDetailRepository.UpdateBookingDetails(bookingDetails);
            return Ok(id);
        }
    }
}
