using HotelProject.Core.Abstracts.IRepositories;
using HotelProject.Core.Abstracts.IService;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using HotelProject.Core.Concrates.Entities;
using HotelProject.Service.Services.Generic;

namespace HotelProject.Service.Services
{
    public class RoomService : GenericService<Room>, IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork) : base(roomRepository, unitOfWork)
        {
            _roomRepository = roomRepository;
        }
    }
}
