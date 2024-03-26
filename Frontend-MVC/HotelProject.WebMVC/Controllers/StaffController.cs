using HotelProject.Core.Concrates.DTOs.StaffDto;
using HotelProject.WebUI.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {

        private readonly StaffApiService _staffApiService;

        public StaffController(StaffApiService staffApiService)
        {
            _staffApiService = staffApiService;
        }

        public async Task<IActionResult> Index()
        {
            var allStaff = await _staffApiService.GetAllStaff();

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
                await _staffApiService.CreateStaff(createStaffDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var staff = await _staffApiService.GetStaffById(id);

            return View(staff);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStaffDTO updateStaffDto)
        {
            if (ModelState.IsValid)
            {
                await _staffApiService.UpdateStaff(updateStaffDto);
                return RedirectToAction(nameof(Index));
            }

            return View(updateStaffDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _staffApiService.DeleteStaff(id);
            return RedirectToAction(nameof(Index));
        }

    }

}