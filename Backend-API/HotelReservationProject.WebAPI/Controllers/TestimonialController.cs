using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.NoContentDto;
using HotelProject.Core.Concrates.DTOs.TestimonialDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.WebAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class TestimonialController : CustomBaseController
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/Testimonial
        [HttpGet]
        public IActionResult GetAllTestimonial()
        {
            var allTestimonial = _service.GetActives();
            var testimonialDtos = _mapper.Map<List<TestimonialDTO>>(allTestimonial.ToList());
            return CreateResult(CustomResponseDTO<List<TestimonialDTO>>.Success(200, testimonialDtos));
        }

        //GET: api/Testimonial/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var testimonial = await _service.FindAsync(id);
            var testimonialDto = _mapper.Map<UpdateTestimonialDTO>(testimonial);
            return CreateResult(CustomResponseDTO<UpdateTestimonialDTO>.Success(200, testimonialDto));
        }

        //CREATE: api/Testimonial
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDTO createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            await _service.AddAsync(testimonial);
            var testimonialDto = _mapper.Map<CreateTestimonialDTO>(testimonial);
            return CreateResult(CustomResponseDTO<CreateTestimonialDTO>.Success(201, testimonialDto)); //201: Created
        }

        //UPDATE: api/Testimonial
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _service.UpdateAsync(testimonial);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }

        //DELETE: api/Testimonial/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _service.FindAsync(id);
            _service.Delete(testimonial);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }
    }
}
