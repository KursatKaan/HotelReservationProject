using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.StaffDto;
using HotelProject.Core.Concrates.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _service;
        private readonly IMapper _mapper;

        public StaffController(IStaffService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/staff
        [HttpGet]
        public IActionResult AllActives()
        {
            var allStaff = _service.GetActives();
            var staffDtos = _mapper.Map<List<StaffDTO>>(allStaff);
            return Ok(staffDtos);
        }

        //GET: api/staff/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _service.FindAsync(id);
            var staffDto = _mapper.Map<StaffDTO>(staff);
            return Ok(staffDto);
        }

        //CREATE: api/staff
        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffDTO createStaffDto)
        {
            var staff = _mapper.Map<Staff>(createStaffDto);
            await _service.AddAsync(staff);
            return StatusCode(201);
        }

        //UPDATE: api/staff
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStaffDTO updateStaffDto)
        {
            var staff = _mapper.Map<Staff>(updateStaffDto);
            await _service.UpdateAsync(staff);
            return NoContent();
        }

        //DELETE: api/staff/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _service.FindAsync(id);
            _service.Delete(staff);
            return NoContent();
        }
    }
}
