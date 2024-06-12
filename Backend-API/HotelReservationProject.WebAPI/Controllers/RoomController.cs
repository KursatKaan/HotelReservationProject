using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.RoomDto;
using HotelProject.Core.Concrates.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        private readonly IMapper _mapper;

        public RoomController(IRoomService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/room
        [HttpGet]
        public IActionResult AllActives()
        {
            var allRoom = _service.GetActives();
            var RoomDtos = _mapper.Map<List<RoomDTO>>(allRoom);
            return Ok(RoomDtos);
        }

        //GET: api/room/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Room = await _service.FindAsync(id);
            var RoomDto = _mapper.Map<RoomDTO>(Room);
            return Ok(RoomDto);
        }

        //CREATE: api/room
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomDTO createRoomDto)
        {
            var Room = _mapper.Map<Room>(createRoomDto);
            await _service.AddAsync(Room);
            return StatusCode(201);
        }

        //UPDATE: api/room
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoomDTO updateRoomDto)
        {
            var Room = _mapper.Map<Room>(updateRoomDto);
            await _service.UpdateAsync(Room);
            return NoContent();
        }

        //DELETE: api/room/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Room = await _service.FindAsync(id);
            _service.Delete(Room);
            return NoContent();
        }
    }
}
