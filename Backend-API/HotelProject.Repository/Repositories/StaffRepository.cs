using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Repository.Repositories.Generic;

namespace HotelProject.Repository.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(AppDbContext context) : base(context)
        {
        }
    }
}
