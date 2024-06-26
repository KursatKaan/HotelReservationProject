﻿using HotelProject.Core.Concrates.Enums;

namespace HotelProject.Core.Concrates.DTOs.AppUserDto
{
    public class UpdateUserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public City City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
