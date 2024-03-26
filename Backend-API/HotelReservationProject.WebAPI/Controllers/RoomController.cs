using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.NoContentDto;
using HotelProject.Core.Concrates.DTOs.RoomDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.WebAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class RoomController : CustomBaseController
    {
        private readonly IRoomService _service;
        private readonly IMapper _mapper;

        public RoomController(IRoomService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/Room
        [HttpGet]
        public IActionResult GetAllRoom()
        {
            var allRooms = _service.GetActives();
            var roomDtos = _mapper.Map<List<RoomDTO>>(allRooms.ToList());
            return CreateResult(CustomResponseDTO<List<RoomDTO>>.Success(200, roomDtos));
        }

        //GET: api/Room/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _service.FindAsync(id);
            var roomDto = _mapper.Map<UpdateRoomDTO>(room);
            return CreateResult(CustomResponseDTO<UpdateRoomDTO>.Success(200, roomDto));
        }

        //CREATE: api/Room
        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomDTO createRoomDto)
        {
            var room = _mapper.Map<Room>(createRoomDto);
            await _service.AddAsync(room);
            var roomDto = _mapper.Map<CreateRoomDTO>(room);
            return CreateResult(CustomResponseDTO<CreateRoomDTO>.Success(201, roomDto)); //201: Created
        }

        //UPDATE: api/Room
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDTO updateRoomDto)
        {
            var room = _mapper.Map<Room>(updateRoomDto);
            await _service.UpdateAsync(room);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }

        //DELETE: api/Room/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _service.FindAsync(id);
            _service.Delete(room);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }
    }
}
