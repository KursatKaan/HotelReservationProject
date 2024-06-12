using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.OurServiceDto;
using HotelProject.Core.Concrates.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/ourservice")]
    [ApiController]
    public class OurServiceController : ControllerBase
    {
        private readonly IOurServiceService _service;
        private readonly IMapper _mapper;

        public OurServiceController(IOurServiceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/ourservice
        [HttpGet]
        public IActionResult AllActives()
        {
            var allOurService = _service.GetActives();
            var OurServiceDtos = _mapper.Map<List<OurServiceDTO>>(allOurService);
            return Ok(OurServiceDtos);
        }

        //GET: api/ourservice/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var OurService = await _service.FindAsync(id);
            var OurServiceDto = _mapper.Map<OurServiceDTO>(OurService);
            return Ok(OurServiceDto);
        }

        //CREATE: api/ourservice
        [HttpPost]
        public async Task<IActionResult> Create(CreateOurServiceDTO createOurServiceDto)
        {
            var OurService = _mapper.Map<OurService>(createOurServiceDto);
            await _service.AddAsync(OurService);
            return StatusCode(201);
        }

        //UPDATE: api/ourservice
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOurServiceDTO updateOurServiceDto)
        {
            var OurService = _mapper.Map<OurService>(updateOurServiceDto);
            await _service.UpdateAsync(OurService);
            return NoContent();
        }

        //DELETE: api/ourservice/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var OurService = await _service.FindAsync(id);
            _service.Delete(OurService);
            return NoContent();
        }
    }
}
