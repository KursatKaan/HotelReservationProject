using HotelProject.Core.Concrates.Entities;
using HotelProject.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HotelProject.Service.DependencyResolvers
{
    public static class IdentityInjection
    {
        public static IServiceCollection AddIdentityInjection(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequiredLength = 8;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
