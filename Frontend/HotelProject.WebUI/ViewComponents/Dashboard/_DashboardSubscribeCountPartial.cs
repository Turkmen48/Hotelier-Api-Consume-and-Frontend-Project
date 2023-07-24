using HotelProject.WebUI.Dtos.DashboardDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardSubscribeCountPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/enes_usta48"),
                Headers =
    {
        { "X-RapidAPI-Key", "db0e9f5923msh1ecd3494ca8834dp1e0a12jsnc532e396d0f9" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<ResultInstagramDto>(body);
                ViewBag.instagramFollowing = value.following;
                ViewBag.instagramFollowers = value.followers;
                
            }

            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=aazdenkur"),
                Headers =
    {
        { "X-RapidAPI-Key", "db0e9f5923msh1ecd3494ca8834dp1e0a12jsnc532e396d0f9" },
        { "X-RapidAPI-Host", "twitter154.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultTwitterDto>(body);
                ViewBag.twitterFollowing = value.following_count;
                ViewBag.twitterFollowers = value.follower_count;
            }
            return View();
        }
    }
}
