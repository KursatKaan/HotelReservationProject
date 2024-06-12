using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
