using HotelProject.Core.Concrates.DTOs.OurServiceDto;
using HotelProject.WebUI.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class OurServiceController : Controller
    {
        private readonly OurServiceApiService _ourServiceApiService;

        public OurServiceController(OurServiceApiService ourServiceApiService)
        {
            _ourServiceApiService = ourServiceApiService;
        }

        public async Task<IActionResult> Index()
        {
            var allOurService = await _ourServiceApiService.GetAllOurService();

            return View(allOurService);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOurServiceDTO createOurServiceDto)
        {
            if (ModelState.IsValid)
            {
                await _ourServiceApiService.CreateOurService(createOurServiceDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var ourService = await _ourServiceApiService.GetOurServiceById(id);

            return View(ourService);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOurServiceDTO updateOurServiceDto)
        {
            if (ModelState.IsValid)
            {
                await _ourServiceApiService.UpdateOurService(updateOurServiceDto);
                return RedirectToAction(nameof(Index));
            }

            return View(updateOurServiceDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _ourServiceApiService.DeleteOurService(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
