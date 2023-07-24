using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5087/api/MessageCategory");
            
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCategory>>(jsonData);
            List<SelectListItem> values2= (from x in values select new SelectListItem
            {
                Text=x.MessageCategoryName,
                Value=x.MessageCategoryID.ToString()
            }).ToList();
            ViewBag.v = values2;
                return View();
           
          
           
        }

        public PartialViewResult AddContact()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var result = await client.PostAsync("http://localhost:5087/api/Contact", stringContent);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Contact");
            }

            return RedirectToAction("Index", "Contact");
        }
    }
}
