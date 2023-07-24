using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking Booking)
        {
            _bookingService.TInsert(Booking);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            _bookingService.TDelete(_bookingService.TGetById(id));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking Booking)
        {
            _bookingService.TUpdate(Booking);
            return Ok();
        }
        [HttpGet("UpdateReservationtoApproved")]
        public IActionResult UpdateReservationtoApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }

        [HttpGet("UpdateReservationtoRefused")]
        public IActionResult UpdateReservationtoRefused(int id)
        {
            _bookingService.TBookingStatusChangeRefused(id);
            return Ok();
        }
        [HttpGet("UpdateReservationtoWaiting")]
        public IActionResult UpdateReservationtoWaiting(int id)
        {
            _bookingService.TBookingStatusChangeWaiting(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
