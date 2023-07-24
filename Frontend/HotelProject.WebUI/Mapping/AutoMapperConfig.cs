using AutoMapper;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.AppUserDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto,Service>().ReverseMap();
            CreateMap<UpdateServiceDto,Service>().ReverseMap();
            CreateMap<CreateServiceDto,Service>().ReverseMap();
            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();
            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();
            CreateMap<ResultStaffDto,Staff>().ReverseMap();
            CreateMap<CreateSubscribeDto,Subscribe>().ReverseMap();
            CreateMap<CreateBookingDto,Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto,Booking>().ReverseMap();
            CreateMap<CreateContactDto,Contact>().ReverseMap();
            CreateMap<CreateGuestDto,Guest>().ReverseMap();
            CreateMap<UpdateGuestDto,Guest>().ReverseMap();
            CreateMap<SendBoxResultDto,SendMessage>().ReverseMap();
            CreateMap<CreateSendMessage,SendMessage>().ReverseMap();
            CreateMap<ResultMessageCategory,MessageCategory>().ReverseMap();
            CreateMap<ResultAppUserDto,AppUser>().ReverseMap();
          

        }
    }
}
