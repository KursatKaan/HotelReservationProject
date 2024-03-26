using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.AppUserDto;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.NoContentDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.WebAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class AppUserController : CustomBaseController
    {
        private readonly IAppUserService _service;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/User
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var allUser = _service.GetActives();
            var userDtos = _mapper.Map<List<UserDTO>>(allUser.ToList());
            return CreateResult(CustomResponseDTO<List<UserDTO>>.Success(200, userDtos));
        }

        //GET: api/User/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.FindAsync(id);
            var userDto = _mapper.Map<UpdateUserDTO>(user);
            return CreateResult(CustomResponseDTO<UpdateUserDTO>.Success(200, userDto));
        }

        //CREATE: api/User
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDto)
        {
            AppUser appUser = new()
            {
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                Email = createUserDto.Email,
                PasswordHash = createUserDto.Password,
                UserName = createUserDto.Email,
                City = createUserDto.City,
                PhoneNumber = createUserDto.PhoneNumber
            };

            bool result = await _service.CreateUserAsync(appUser);
            if (result)
            {
                var userDto = _mapper.Map<UserDTO>(appUser);
                return CreateResult(CustomResponseDTO<UserDTO>.Success(201, userDto)); //201: Created
            }
            return BadRequest("An error occurred while creating the user");

            //var user = _mapper.Map<AppUser>(createUserDto);
            //await _service.CreateUserAsync(user);
            //var userDto = _mapper.Map<CreateUserDTO>(user);
            //return CreateResult(CustomResponseDTO<CreateUserDTO>.Success(201, userDto)); //201: Created
        }

        //UPDATE: api/User
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updateUserDto)
        {
            var user = _mapper.Map<AppUser>(updateUserDto);
            await _service.UpdateAsync(user);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }

        //DELETE: api/User/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _service.FindAsync(id);
            _service.Delete(user);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }
    }
}
