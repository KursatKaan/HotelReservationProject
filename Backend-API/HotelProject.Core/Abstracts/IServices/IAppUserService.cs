using HotelProject.Core.Abstracts.IService.Generic;
using HotelProject.Core.Concrates.Entities;

namespace HotelProject.Core.Abstracts.IService
{
    public interface IAppUserService : IService<AppUser>
    {
        Task<bool> CreateUserAsync(AppUser user);
    }
}
