using Books.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Books.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            IEnumerable<T> entities = await _dbSet.ToListAsync();

            return entities;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = await _dbSet.Where(predicate).ToListAsync();

            return entities;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            T entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"Сущности {typeof(T).Name} с {typeof(T).GetProperties().FirstOrDefault().Name} \"{id}\" не существует");
            }

            return entity;
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            T entity = await _dbSet.FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                throw new Exception($"Сущности {typeof(T).Name} с {typeof(T).GetProperties().FirstOrDefault().Name} \"\" не существует");
            }

            return entity;
        }

        public virtual async Task<IEnumerable<T>> CheckCountAndGet(Expression<Func<T, bool>> predicate, int count)
        {
            IEnumerable<T> entites = await _dbSet.Where(predicate).ToListAsync();

            if (entites.Count() != count)
            {
                throw new Exception("Одной или нескольких из указанных сущностей не существует");
            }

            return entites;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
