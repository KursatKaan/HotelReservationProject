using HotelProject.Core.Abstracts.IEntities;

namespace HotelProject.Core.Concrates.Entities
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public int RoomPrice { get; set; }
        public string RoomTitle { get; set; }
        public string RoomBedCount { get; set; }
        public string RoomBathCount { get; set; }
        public string RoomWifi { get; set; }
        public string RoomDescription { get; set; }
    }
}
