using HotelProject.WebUI.Models.AdminContact;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.AdminContact
{
    public class _InboxSendboxPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _InboxSendboxPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult > InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("http://localhost:5087/api/Contact/GetContactCount");
            var result2 = await client.GetAsync("http://localhost:5087/api/SendMessage/GetSendMessageCount");
            
            if (result.IsSuccessStatusCode)
            {
                var contactCount = await result.Content.ReadAsStringAsync();
                var sendBoxCount = await result2.Content.ReadAsStringAsync();
                InboxSendboxResult inboxSendboxResult = new InboxSendboxResult()
                {
                    InBoxCount = contactCount,
                    SendBoxCount = sendBoxCount
                };
                return View(inboxSendboxResult);
            }
            return View();
        }
    }
}
