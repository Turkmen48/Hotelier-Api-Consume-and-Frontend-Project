using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("http://localhost:5087/api/Contact");
           
            if (result.IsSuccessStatusCode)
            {
                var jsonData=await result.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<IEnumerable<InboxContactDto>>(jsonData);
                return View(values.OrderByDescending(x => x.ContactID));
            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("http://localhost:5087/api/SendMessage");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<SendBoxResultDto>>(jsonData);
                return View(values.OrderByDescending(x=>x.SendMessageID));
            }
            return View();
        }

        public async Task< IActionResult> MessageDetails(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5087/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5087/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "Admin";
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5087/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
     

        public PartialViewResult SideBarContactCategoryPartial()
        {
            return PartialView();
        }

        //public async Task<IActionResult> GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var result = await client.GetAsync("http://localhost:5087/api/Contact/GetContactCount");
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var jsonData = await result.Content.ReadAsStringAsync();
        //        ViewBag.data = jsonData;
        //        return View();
        //    }
        //    return View();
        //}
    }
}
