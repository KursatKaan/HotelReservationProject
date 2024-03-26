namespace HotelProject.Core.Abstracts.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
