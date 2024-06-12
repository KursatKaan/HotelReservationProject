using HotelProject.Core.Concrates.DTOs.TestimonialDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly HttpClient _httpClient;

        public TestimonialController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("TestimonialApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var allTestimonial = await _httpClient.GetFromJsonAsync<List<TestimonialDTO>>("api/testimmonial");

            return View(allTestimonial);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDTO createTestimonialDto)
        {
            if (!ModelState.IsValid)
                return View();

            await _httpClient.PostAsJsonAsync("api/testimmonial", createTestimonialDto);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {

            var Testimonial = await _httpClient.GetFromJsonAsync<UpdateTestimonialDTO>($"api/testimmonial/{id}");

            return View(Testimonial);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDTO updateTestimonialDto)
        {
            if (!ModelState.IsValid)
                return View(updateTestimonialDto);

            await _httpClient.PutAsJsonAsync("api/testimmonial", updateTestimonialDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/testimmonial/{id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
