using HotelProject.Core.Concrates.DTOs.TestimonialDto;
using HotelProject.WebUI.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly TestimonialApiService _testimonialApiService;

        public TestimonialController(TestimonialApiService testimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
        }

        public async Task<IActionResult> Index()
        {
            var allTestimonial = await _testimonialApiService.GetAllTestimonial();

            return View(allTestimonial);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDTO createTestimonialDto)
        {
            if (ModelState.IsValid)
            {
                await _testimonialApiService.CreateTestimonial(createTestimonialDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var testimonial = await _testimonialApiService.GetTestimonialById(id);

            return View(testimonial);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDTO updateTestimonialDto)
        {
            if (ModelState.IsValid)
            {
                await _testimonialApiService.UpdateTestimonial(updateTestimonialDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialApiService.DeleteTestimonial(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
