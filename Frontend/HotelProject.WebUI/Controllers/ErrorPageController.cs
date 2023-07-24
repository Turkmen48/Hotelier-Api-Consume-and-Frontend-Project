using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                Code = code
           };
            return View(model);
        }
    }
}
