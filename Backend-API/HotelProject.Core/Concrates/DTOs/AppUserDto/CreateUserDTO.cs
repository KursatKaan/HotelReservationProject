using HotelProject.Core.Concrates.Enums;

namespace HotelProject.Core.Concrates.DTOs.AppUserDto
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Password { get; set; }
    }
}
