using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService AboutService)
        {
            _aboutService = AboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddAbout(About About)
        {
            _aboutService.TInsert(About);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(_aboutService.TGetById(id));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAbout(About About)
        {
            _aboutService.TUpdate(About);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
