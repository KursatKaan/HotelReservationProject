using HotelProject.Core.Concrates.DTOs.OurServiceDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class OurServiceController : Controller
    {
        private readonly HttpClient _httpClient;

        public OurServiceController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("OurServiceApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var allOurService = await _httpClient.GetFromJsonAsync<List<OurServiceDTO>>("api/ourservice");

            return View(allOurService);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOurServiceDTO createOurServiceDto)
        {
            if (!ModelState.IsValid)
                return View();

            await _httpClient.PostAsJsonAsync("api/ourservice", createOurServiceDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {

            var ourService = await _httpClient.GetFromJsonAsync<UpdateOurServiceDTO>($"api/ourservice/{id}");

            return View(ourService);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOurServiceDTO updateOurServiceDto)
        {
            if (!ModelState.IsValid)
                return View(updateOurServiceDto);

            await _httpClient.PutAsJsonAsync("api/ourservice", updateOurServiceDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/ourservice/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
