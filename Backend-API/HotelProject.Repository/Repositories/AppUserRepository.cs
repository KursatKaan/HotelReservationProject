using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Repository.Repositories.Generic;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.Repository.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        UserManager<AppUser> _userManager;

        public AppUserRepository(AppDbContext context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUserAsync(AppUser user)
        {
            IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash);

            if (result.Succeeded)
                return true;

            return false;
        }
    }
}
