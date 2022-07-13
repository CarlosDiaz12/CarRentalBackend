using CarRental.Domain.Entities;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CarRentalContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(CarRentalContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null,
             int? take = null, int? skip = null)
        {
            IQueryable<TEntity> result = _dbSet;

            if (filter != null)
                result = result.Where(filter);

            if (take.HasValue && skip.HasValue)
            {
                var pageIndex = skip.Value;
                var pageSize = take.Value;
                result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            return await result.ToListAsync();
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            _dbSet.Remove(entity);
        }

        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbContext.Attach(entity);

            _dbSet.Update(entity);
        }
    }
}
