using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Repository.Repositories.Generic;

namespace HotelProject.Repository.Repositories;

public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
{
    public TestimonialRepository(AppDbContext context) : base(context)
    {
    }
}