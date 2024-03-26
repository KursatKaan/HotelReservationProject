using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.NoContentDto;
using HotelProject.Core.Concrates.DTOs.StaffDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.WebAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class StaffController : CustomBaseController
    {
        private readonly IStaffService _service;
        private readonly IMapper _mapper;

        public StaffController(IStaffService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/Staff
        [HttpGet]
        public IActionResult GetAllStaff()
        {
            var allStaff = _service.GetActives();
            var staffDtos = _mapper.Map<List<StaffDTO>>(allStaff.ToList());
            return CreateResult(CustomResponseDTO<List<StaffDTO>>.Success(200, staffDtos));
        }

        //GET: api/Staff/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _service.FindAsync(id);
            var staffDto = _mapper.Map<UpdateStaffDTO>(staff);
            return CreateResult(CustomResponseDTO<UpdateStaffDTO>.Success(200, staffDto));
        }

        //CREATE: api/Staff
        [HttpPost]
        public async Task<IActionResult> CreateStaff(CreateStaffDTO createStaffDto)
        {
            var staff = _mapper.Map<Staff>(createStaffDto);
            await _service.AddAsync(staff);
            var staffDto = _mapper.Map<CreateStaffDTO>(staff);
            return CreateResult(CustomResponseDTO<CreateStaffDTO>.Success(201, staffDto)); //201: Created
        }

        //UPDATE: api/Staff
        [HttpPut]
        public async Task<IActionResult> UpdateStaff(UpdateStaffDTO updateStaffDto)
        {
            var staff = _mapper.Map<Staff>(updateStaffDto);
            await _service.UpdateAsync(staff);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }

        //DELETE: api/Staff/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _service.FindAsync(id);
            _service.Delete(staff);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }
    }
}
