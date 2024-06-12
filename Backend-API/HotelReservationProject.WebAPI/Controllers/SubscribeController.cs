using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.SubscribeDto;
using HotelProject.Core.Concrates.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/subscribe")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _service;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscribeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/subscribe
        [HttpGet]
        public IActionResult AllActives()
        {
            var allSubscribe = _service.GetActives();
            var subscribeDtos = _mapper.Map<List<SubscribeDTO>>(allSubscribe);
            return Ok(subscribeDtos);
        }

        //GET: api/subscribe/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscribe = await _service.FindAsync(id);
            var subscribeDto = _mapper.Map<SubscribeDTO>(subscribe);
            return Ok(subscribeDto);
        }

        //CREATE: api/subscribe
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscribeDTO createSubscribeDto)
        {
            var subscribe = _mapper.Map<Subscribe>(createSubscribeDto);
            await _service.AddAsync(subscribe);
            return StatusCode(201);
        }

        //UPDATE: api/subscribe
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscribeDTO updateSubscribeDto)
        {
            var subscribe = _mapper.Map<Subscribe>(updateSubscribeDto);
            await _service.UpdateAsync(subscribe);
            return NoContent();
        }

        //DELETE: api/subscribe/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subscribe = await _service.FindAsync(id);
            _service.Delete(subscribe);
            return NoContent();
        }
    }
}
