using HotelProject.Core.Abstracts.IEntities;
using HotelProject.Core.Abstracts.IRepositories.Generic;
using HotelProject.Core.Concrates.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelProject.Repository.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking() //AsNoTracking: Çekilen veriyi hafızaya almayarak performansı arttırır.
                    .AsQueryable();
        }

        public IQueryable<T> GetActives()
        {
            return Where(x => x.Status != DataStatus.Deleted); // Statusu deleted olmayanlar.
        }

        public IQueryable<T> GetModifieds()
        {
            return Where(x => x.Status == DataStatus.Updated); // Statusu updated olanlar.
        }

        public IQueryable<T> GetPassives()
        {
            return Where(x => x.Status == DataStatus.Deleted); // Statusu deleted olanlar.
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.Status = DataStatus.Updated;
            entity.ModifiedDate = DateTime.Now;

            T original = await FindAsync(entity.ID);
            _dbSet.Entry(original).CurrentValues.SetValues(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await UpdateAsync(entity);
        }

        /// <summary>
        /// Veriyi pasife çeker. Tamamen silmez.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            entity.Status = DataStatus.Deleted;
            entity.DeletedDate = DateTime.Now;
        }

        /// <summary>
        /// Verileri pasife çekıer. Tamamen silmez.
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Delete(entity);
        }

        /// <summary>
        /// Veriyi tamamen siler.
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Veeriyi tamamen siler.
        /// </summary>
        /// <param name="entities"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Where(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.AnyAsync(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.FirstOrDefaultAsync(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _dbSet.Select(exp);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
