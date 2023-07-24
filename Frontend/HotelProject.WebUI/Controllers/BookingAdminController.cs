using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("http://localhost:5087/api/Booking");
            
            if (result.IsSuccessStatusCode)
            {
                var jsonData= await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5087/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5087/api/Booking", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {


                    return RedirectToAction("Index", "BookingAdmin");
                }
            }
            return View();
        }
        public async Task<IActionResult> ApproveReservation(int id) {
            var client = _httpClientFactory.CreateClient();
            
            
            var responseMessage = await client.GetAsync($"http://localhost:5087/api/Booking/UpdateReservationtoApproved?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BookingAdmin");
            }
            return RedirectToAction("Index", "BookingAdmin");

        }

        public async Task<IActionResult> RefuseReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:5087/api/Booking/UpdateReservationtoRefused?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BookingAdmin");
            }
            return RedirectToAction("Index", "BookingAdmin");

        }
        public async Task<IActionResult> WaitReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:5087/api/Booking/UpdateReservationtoWaiting?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BookingAdmin");
            }
            return RedirectToAction("Index", "BookingAdmin");

        }
    }
}
