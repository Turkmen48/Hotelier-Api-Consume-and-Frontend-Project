using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _categoryService;

        public MessageCategoryController(IMessageCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(MessageCategory messageCategory)
        {
            _categoryService.TInsert(messageCategory);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(_categoryService.TGetById(id));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory(MessageCategory messageCategory)
        {
            _categoryService.TUpdate(messageCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}
