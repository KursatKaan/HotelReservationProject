using HotelProject.Core.Concrates.DTOs.AppUserDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegisterController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("UserApiClient");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateUserDTO createUserDTO)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync("api/user/register", createUserDTO);

                return RedirectToAction("Index", "Login");

                //return RedirectToAction(nameof(LoginController.Index), nameof(LoginController).Replace("Controller", ""));
            }

            return View();
        }
    }
}
