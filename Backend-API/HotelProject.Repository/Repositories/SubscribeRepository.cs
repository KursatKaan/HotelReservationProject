using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Repository.Repositories.Generic;

namespace HotelProject.Repository.Repositories;

public class SubscribeRepository : GenericRepository<Subscribe>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext context) : base(context)
    {
    }
}