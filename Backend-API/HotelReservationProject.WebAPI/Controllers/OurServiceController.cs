using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.NoContentDto;
using HotelProject.Core.Concrates.DTOs.OurServiceDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.WebAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class OurServiceController : CustomBaseController
    {
        private readonly IOurServiceService _service;
        private readonly IMapper _mapper;

        public OurServiceController(IOurServiceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/OurService
        [HttpGet]
        public IActionResult GetAllOurService()
        {
            var allOurServices = _service.GetActives();
            var ourServiceDtos = _mapper.Map<List<OurServiceDTO>>(allOurServices.ToList());
            return CreateResult(CustomResponseDTO<List<OurServiceDTO>>.Success(200, ourServiceDtos));
        }

        //GET: api/OurService/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOurServiceById(int id)
        {
            var ourService = await _service.FindAsync(id);
            var ourServiceDto = _mapper.Map<UpdateOurServiceDTO>(ourService);
            return CreateResult(CustomResponseDTO<UpdateOurServiceDTO>.Success(200, ourServiceDto));
        }

        //CREATE: api/OurService
        [HttpPost]
        public async Task<IActionResult> CreateOurService(CreateOurServiceDTO createOurServiceDto)
        {
            var ourService = _mapper.Map<OurService>(createOurServiceDto);
            await _service.AddAsync(ourService);
            var ourServiceDto = _mapper.Map<CreateOurServiceDTO>(ourService);
            return CreateResult(CustomResponseDTO<CreateOurServiceDTO>.Success(201, ourServiceDto)); //201: Created
        }

        //UPDATE: api/OurService
        [HttpPut]
        public async Task<IActionResult> UpdateOurService(UpdateOurServiceDTO updateOurServiceDto)
        {
            var ourService = _mapper.Map<OurService>(updateOurServiceDto);
            await _service.UpdateAsync(ourService);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }

        //DELETE: api/OurService/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOurService(int id)
        {
            var ourService = await _service.FindAsync(id);
            _service.Delete(ourService);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }
    }
}
