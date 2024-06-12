using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
