using HotelProject.Core.Concrates.DTOs.RoomDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("RoomApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var allRoom = await _httpClient.GetFromJsonAsync<List<RoomDTO>>("api/room");

            return View(allRoom);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomDTO createRoomDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync("api/room", createRoomDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var Room = await _httpClient.GetFromJsonAsync<UpdateRoomDTO>($"api/room/{id}");

            return View(Room);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoomDTO updateRoomDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PutAsJsonAsync("api/room", updateRoomDto);

                return RedirectToAction(nameof(Index));
            }

            return View(updateRoomDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/room/{id}");

            return RedirectToAction(nameof(Index));
        }

    }
}

