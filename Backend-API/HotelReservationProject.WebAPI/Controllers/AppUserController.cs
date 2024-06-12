using AutoMapper;
using HotelProject.Core.Concrates.DTOs.AppUserDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Core.Concrates.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private IPasswordHasher<AppUser> _passwordHasher;
        private readonly IMapper _mapper;

        public AppUserController(IMapper mapper, UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher = null)
        {

            _mapper = mapper;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        //GET: api/user
        [HttpGet]
        public async Task<IActionResult> AllActiveUsers()
        {
            var activeUsers = await _userManager.Users
                                                .Where(u => u.Status != DataStatus.Deleted)
                                                .ToListAsync();

            var userDtos = _mapper.Map<List<UserDTO>>(activeUsers);

            return Ok(userDtos);
        }

        //GET: api/user/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return NotFound();

            var userDto = _mapper.Map<UserDTO>(user);

            return Ok(userDto);
        }

        //CREATE: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO createUserDto)
        {
            AppUser appUser = new()
            {
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                UserName = createUserDto.Email,
                Email = createUserDto.Email,
                PasswordHash = createUserDto.Password,
                PhoneNumber = createUserDto.PhoneNumber,
                City = createUserDto.City,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(appUser);

            if (!result.Succeeded)
                return BadRequest();

            return StatusCode(201);

        }

        //UPDATE: api/user
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO updateUserDto)
        {
            var user = await _userManager.FindByEmailAsync(updateUserDto.Email);

            if (user == null)
                return NotFound();

            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;
            user.UserName = updateUserDto.Email;
            user.Email = updateUserDto.Email;
            user.PasswordHash = _passwordHasher.HashPassword(user, updateUserDto.Password);
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.City = updateUserDto.City;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest();

            user.Status = DataStatus.Updated;
            user.ModifiedDate = DateTime.Now;

            return NoContent();
        }

        //DELETE: api/user/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return NotFound();

            user.Status -= DataStatus.Deleted;
            user.DeletedDate = DateTime.Now;

            return NoContent();
        }
    }
}
