using HotelProject.Core.Abstracts.IEntities;
using HotelProject.Core.Concrates.Enums;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.Core.Concrates.Entities
{
    public class AppRole : IdentityRole<int>, IEntity
    {
        public AppRole()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}
