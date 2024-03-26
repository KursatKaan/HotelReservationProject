using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Repository.Repositories.Generic;

namespace HotelProject.Repository.Repositories
{
    public class OurServiceRepository : GenericRepository<OurService>, IOurServiceRepository
    {
        public OurServiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
