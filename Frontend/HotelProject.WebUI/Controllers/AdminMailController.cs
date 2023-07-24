using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelieradmin","admin@hotelier.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder= new BodyBuilder();

            bodyBuilder.HtmlBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = model.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("liathecat48@gmail.com", "atlrulqrhofpgulf");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            var client = _httpClientFactory.CreateClient();
            CreateSendMessage createSendMessage = new CreateSendMessage()
            {
                Content = model.Body,
                ReceiverMail = model.ReceiverMail,
                ReceiverName ="User",
                SenderMail = model.SenderMail??"admin@hotiler.com",
                SenderName="Admin",
                Title= model.Subject
            };
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var result = await client.PostAsync("http://localhost:5087/api/SendMessage",stringContent);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox", "AdminContact");
            }
            return View();
        }
    }
}
