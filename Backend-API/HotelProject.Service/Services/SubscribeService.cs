using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Service.Services.Generic;

namespace HotelProject.Service.Services
{
    public class SubscribeService : GenericService<Subscribe>, ISubscribeService
    {
        private readonly ISubscribeRepository _subscribeRepository;
        public SubscribeService(ISubscribeRepository subscribeRepository, IUnitOfWork unitOfWork) : base(subscribeRepository, unitOfWork)
        {
            _subscribeRepository = subscribeRepository;
        }
    }
}
