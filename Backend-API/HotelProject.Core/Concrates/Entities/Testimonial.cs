using HotelProject.Core.Abstracts.IEntities;

namespace HotelProject.Core.Concrates.Entities
{
    public class Testimonial : BaseEntity
    {
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialDescription { get; set; }
        public string TestimonialImage { get; set; }
    }
}
