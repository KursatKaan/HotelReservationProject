using HotelProject.Core.Concrates.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelProject.Repository.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
        }
    }
}
