using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents
{
    public class StaffViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
