﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            sendMessage.Date = DateTime.Now;
            _sendMessageService.TInsert(sendMessage);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSendMessage(int id)
        {
            _sendMessageService.TDelete(_sendMessageService.TGetById(id));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _sendMessageService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            var value = _sendMessageService.TGetSendMessageCount();
            return Ok(value);
        }
    }
}