using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.TestimonialDto;
using HotelProject.Core.Concrates.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/testimmonial")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/testimmonial
        [HttpGet]
        public IActionResult AllActives()
        {
            var allTestimonial = _service.GetActives();
            var testimonialDtos = _mapper.Map<List<TestimonialDTO>>(allTestimonial);
            return Ok(testimonialDtos);
        }

        //GET: api/testimmonial/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testimonial = await _service.FindAsync(id);
            var testimonialDto = _mapper.Map<TestimonialDTO>(testimonial);
            return Ok(testimonialDto);
        }

        //CREATE: api/testimmonial
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDTO createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            await _service.AddAsync(testimonial);
            return StatusCode(201);
        }

        //UPDATE: api/testimmonial
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDTO updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _service.UpdateAsync(testimonial);
            return NoContent();
        }

        //DELETE: api/testimmonial/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = await _service.FindAsync(id);
            _service.Delete(testimonial);
            return NoContent();
        }
    }
}
