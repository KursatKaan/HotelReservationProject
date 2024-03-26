using AutoMapper;
using HotelProject.Core.Concrates.DTOs.AppUserDto;
using HotelProject.Core.Concrates.DTOs.OurServiceDto;
using HotelProject.Core.Concrates.DTOs.RoomDto;
using HotelProject.Core.Concrates.DTOs.StaffDto;
using HotelProject.Core.Concrates.DTOs.SubscribeDto;
using HotelProject.Core.Concrates.DTOs.TestimonialDto;
using HotelProject.Core.Concrates.Entities;

namespace HotelProject.Service.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<OurService, OurServiceDTO>().ReverseMap();
            CreateMap<OurService, CreateOurServiceDTO>().ReverseMap();
            CreateMap<OurService, UpdateOurServiceDTO>().ReverseMap();

            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, CreateRoomDTO>().ReverseMap();
            CreateMap<Room, UpdateRoomDTO>().ReverseMap();

            CreateMap<Staff, StaffDTO>().ReverseMap();
            CreateMap<Staff, CreateStaffDTO>().ReverseMap();
            CreateMap<Staff, UpdateStaffDTO>().ReverseMap();

            CreateMap<Subscribe, SubscribeDTO>().ReverseMap();
            CreateMap<Subscribe, CreateSubscribeDTO>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDTO>().ReverseMap();

            CreateMap<Testimonial, TestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();

            CreateMap<AppUser, UserDTO>()
                .ForMember(x=>x.ID, opt => opt.MapFrom(src=>src.Id)) // ID özelliğini eşleştir
                .ReverseMap(); 
            CreateMap<AppUser, CreateUserDTO>().ReverseMap();
            CreateMap<AppUser, UpdateUserDTO>().ReverseMap();
        }
    }
}
