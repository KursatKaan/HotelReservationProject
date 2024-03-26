using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Service.Services.Generic;

namespace HotelProject.Service.Services
{
    public class AppUserService : GenericService<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository, IUnitOfWork unitOfWork) : base(appUserRepository, unitOfWork)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<bool> CreateUserAsync(AppUser user)
        {
            return await _appUserRepository.AddUserAsync(user);
        }
    }
}
