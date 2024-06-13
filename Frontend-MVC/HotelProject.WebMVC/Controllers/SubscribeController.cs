using HotelProject.Core.Concrates.DTOs.SubscribeDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly HttpClient _httpClient;

        public SubscribeController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("SubscribeApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var allSubscribe = await _httpClient.GetFromJsonAsync<List<SubscribeDTO>>("api/subscribe");

            return View(allSubscribe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscribeDTO createSubscribeDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync("api/subscribe", createSubscribeDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var Subscribe = await _httpClient.GetFromJsonAsync<UpdateSubscribeDTO>($"api/subscribe/{id}");

            return View(Subscribe);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSubscribeDTO updateSubscribeDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PutAsJsonAsync("api/subscribe", updateSubscribeDto);

                return RedirectToAction(nameof(Index));
            }

            return View(updateSubscribeDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/subscribe/{id}");

            return RedirectToAction(nameof(Index));
        }

    }
}

