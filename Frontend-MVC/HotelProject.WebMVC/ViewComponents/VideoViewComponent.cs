using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents
{
    public class VideoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
