using HotelProject.Core.Abstracts.IEntities;
using HotelProject.Core.Abstracts.IRepositories.Generic;
using HotelProject.Core.Abstracts.IService.Generic;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using System.Linq.Expressions;

namespace HotelProject.Service.Services.Generic
{
    public class GenericService<T> : IService<T> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> GetActives()
        {
            return _repository.GetActives();
        }

        public IQueryable<T> GetModifieds()
        {
            return _repository.GetModifieds();
        }

        public IQueryable<T> GetPassives()
        {
            return _repository.GetPassives();
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            await _repository.UpdateRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.CommitAsync();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _repository.DeleteRange(entities);
            _unitOfWork.CommitAsync();
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _unitOfWork.CommitAsync();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _repository.AnyAsync(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _repository.FirstOrDefaultAsync(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _repository.Select(exp);
        }

        public async Task<T> FindAsync(int id)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
                throw new Exception($"{typeof(T).Name} ({id}) not found");

            return entity;
        }
    }
}
