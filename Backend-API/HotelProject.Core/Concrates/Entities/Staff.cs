using HotelProject.Core.Abstracts.IEntities;

namespace HotelProject.Core.Concrates.Entities
{
    public class Staff : BaseEntity
    {
        public string StaffName { get; set; }
        public string StaffTitle { get; set; }
        public string StaffSocialMedia { get; set; }
        public string StaffSocialMedia2 { get; set; }
        public string StaffSocialMedia3 { get; set; }


    }
}
