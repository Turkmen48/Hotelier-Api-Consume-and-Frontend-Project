using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidatonRules
{
    public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soy isim boş geçilemez");
            RuleFor(x=>x.City).NotEmpty().WithMessage("Şehir boş geçilemez");
            RuleFor(x=>x.City).MinimumLength(3).WithMessage("Şehir adı en az 3 karkaterden oluşmalı");
            RuleFor(x=>x.Name).MinimumLength(3).WithMessage("İsim en az 3 karkaterden oluşmalı");
            RuleFor(x=>x.Name).MaximumLength(20).WithMessage("İsim en fazla 20 karkaterden oluşmalı");
            RuleFor(x=>x.City).MaximumLength(20).WithMessage("Şehir en fazla 20 karkaterden oluşmalı");
            RuleFor(x=>x.Surname).MaximumLength(20).WithMessage("Soy isim en fazla 20 karkaterden oluşmalı");
        }
    }
}
