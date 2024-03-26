using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Service.Services.Generic;

namespace HotelProject.Service.Services
{
    public class OurServiceService : GenericService<OurService>, IOurServiceService
    {
        private readonly IOurServiceRepository _ourServiceRepository;
        public OurServiceService(IOurServiceRepository ourServiceRepository, IUnitOfWork unitOfWork) : base(ourServiceRepository, unitOfWork)
        {
            _ourServiceRepository = ourServiceRepository;
        }
    }
}
