using System.Runtime.Serialization;
using HotelProject.Core.Abstracts.IEntities;
using HotelProject.Core.Concrates.Enums;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.Core.Concrates.Entities
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }


        //User Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }

    }
}
