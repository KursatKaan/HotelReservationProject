using HotelProject.Core.Concrates.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelProject.Repository.Configurations
{
    public class AppRoleConfiguration : BaseConfiguration<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
        }
    }
}
