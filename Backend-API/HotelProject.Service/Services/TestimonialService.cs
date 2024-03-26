using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Service.Services.Generic;

namespace HotelProject.Service.Services
{
    public class TestimonialService : GenericService<Testimonial>, ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository, IUnitOfWork unitOfWork) : base(testimonialRepository, unitOfWork)
        {
            _testimonialRepository = testimonialRepository;
        }
    }
}
