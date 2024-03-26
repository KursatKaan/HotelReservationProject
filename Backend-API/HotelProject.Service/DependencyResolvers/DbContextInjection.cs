using HotelProject.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelProject.Service.DependencyResolvers
{
    public static class DbContextInjection
    {
        //API katmanına Repository(DAL) katmanını referans vermemek için bu şekilde service katmanından enjekte ettim.
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection"))
                .UseLazyLoadingProxies());

            return services;
        }
    }
}
