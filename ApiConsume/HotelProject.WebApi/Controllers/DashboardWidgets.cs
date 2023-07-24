using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgets : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgets(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount() {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public IActionResult AppUserCount()
        {
            var value = _appUserService.TAppUserCount();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public IActionResult RoomCount()
        {
            var value = _roomService.TRoomCount();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public IActionResult Last4Staff()
        {
            var value = _staffService.TLast4Staff();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public IActionResult Last6Booking()
        {
            var value = _bookingService.TLast6Booking();
            return Ok(value);
        }
    }
}
