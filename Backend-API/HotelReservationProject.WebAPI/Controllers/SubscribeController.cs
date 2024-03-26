using AutoMapper;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.NoContentDto;
using HotelProject.Core.Concrates.DTOs.SubscribeDto;
using HotelProject.Core.Concrates.Entities;
using HotelProject.WebAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class SubscribeController : CustomBaseController
    {
        private readonly ISubscribeService _service;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscribeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/Subscribe
        [HttpGet]
        public IActionResult GetAllSubscribe()
        {
            var allSubscribe = _service.GetActives();
            var subscribeDtos = _mapper.Map<List<SubscribeDTO>>(allSubscribe.ToList());
            return CreateResult(CustomResponseDTO<List<SubscribeDTO>>.Success(200, subscribeDtos));
        }

        //GET: api/Subscribe/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribeById(int id)
        {
            var subscribe = await _service.FindAsync(id);
            var subscribeDto = _mapper.Map<UpdateSubscribeDTO>(subscribe);
            return CreateResult(CustomResponseDTO<UpdateSubscribeDTO>.Success(200, subscribeDto));
        }

        //CREATE: api/Subscribe
        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDTO createSubscribeDto)
        {
            var subscribe = _mapper.Map<Subscribe>(createSubscribeDto);
            await _service.AddAsync(subscribe);
            var subscribeDto = _mapper.Map<CreateSubscribeDTO>(subscribe);
            return CreateResult(CustomResponseDTO<CreateSubscribeDTO>.Success(201, subscribeDto)); //201: Created
        }

        //UPDATE: api/Subscribe
        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDTO updateSubscribeDto)
        {
            var subscribe = _mapper.Map<Subscribe>(updateSubscribeDto);
            await _service.UpdateAsync(subscribe);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }

        //DELETE: api/Subscribe/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var subscribe = await _service.FindAsync(id);
            _service.Delete(subscribe);
            return CreateResult(CustomResponseDTO<NoContentDTO>.Success(204)); //204: No Content
        }
    }
}
