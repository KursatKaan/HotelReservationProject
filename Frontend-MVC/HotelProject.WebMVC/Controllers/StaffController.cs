using HotelProject.Core.Concrates.DTOs.StaffDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {

        private readonly HttpClient _httpClient;

        public StaffController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("StaffApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var allStaff = await _httpClient.GetFromJsonAsync<List<StaffDTO>>("api/staff");

            return View(allStaff);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffDTO createStaffDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync("api/staff", createStaffDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var staff = await _httpClient.GetFromJsonAsync<UpdateStaffDTO>($"api/staff/{id}");

            return View(staff);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStaffDTO updateStaffDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PutAsJsonAsync("api/staff", updateStaffDto);

                return RedirectToAction(nameof(Index));
            }

            return View(updateStaffDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/staff/{id}");

            return RedirectToAction(nameof(Index));
        }

    }

}