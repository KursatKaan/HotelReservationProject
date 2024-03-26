using HotelProject.Core.Abstracts.IEntities;

namespace HotelProject.Core.Concrates.Entities
{
    public class OurService : BaseEntity
    {
        public string OurServiceIcon { get; set; }
        public string OurServiceTitle { get; set; }
        public string OurServiceDescription { get; set; }
    }
}
