using Books.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Books.Repositories.Base
{
    /// <summary>
    /// Сложный базовый репозиторий (если с элементом нужно загрузить вложенные элементы)
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    /// <typeparam name="TProperty">Вложенная сущность</typeparam>
    public class BaseComplicatedRepository<T, TProperty> : BaseRepository<T>, IBaseComplicatedRepository<T, TProperty>
        where T : class
        where TProperty : class
    {
        public BaseComplicatedRepository(AppDbContext context) : base(context)
        {
            _dbSet.Include(typeof(T).GetProperties().LastOrDefault().Name).Load(); // загружаем контекст данных с вложенными элементами
        }

        /// <summary>
        /// Получение элементов с вложенными элементами
        /// </summary>
        public override async Task<IEnumerable<T>> GetAsync()
        {
            IEnumerable<T> entities = await _dbSet.ToListAsync();

            return entities;
        }

        /// <summary>
        /// Получение элемента с вложенными элементами по условию
        /// </summary>
        public override async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            T entity = await _dbSet.FirstOrDefaultAsync(predicate);

            return entity;
        }

        /// <summary>
        /// Обновление с зависимыми элементами
        /// </summary>
        public override async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
