using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        [NonAction] //Endpoint olmadığını bildiriyoruz.
        public IActionResult CreateResult<T>(CustomResponseDTO<T> response)
        {
            if (response.StatusCode == 204) //204 no content demektir.
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

    }
}
