﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService ServiceService)
        {
            _serviceService = ServiceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service Service)
        {
            _serviceService.TInsert(Service);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(_serviceService.TGetById(id));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(Service Service)
        {
            _serviceService.TUpdate(Service);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }
    }
}
