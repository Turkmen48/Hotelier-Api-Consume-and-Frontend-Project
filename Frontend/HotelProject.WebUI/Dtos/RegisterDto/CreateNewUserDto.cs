using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar zorunludur")]
        [Compare("Password",ErrorMessage ="Şifreler aynı olmalı")]
        public string ConfirmPassword { get; set; }

       
    }
}
