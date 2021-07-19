using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Books.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Получение всех элементов
        /// </summary>
        Task<IEnumerable<T>> GetAsync();
        /// <summary>
        /// Получение множества элементов по условию
        /// </summary>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Получение элемента по id
        /// </summary>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Получение элемента по условию
        /// </summary>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Проверка, соответствует ли найденное количество зависимых элементов ожидаемому количеству
        /// </summary>
        Task<IEnumerable<T>> CheckCountAndGet(Expression<Func<T, bool>> predicate, int count);
        /// <summary>
        /// Создание элемента
        /// </summary>
        Task CreateAsync(T entity);
        /// <summary>
        /// Обновление элемента
        /// </summary>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Удаление элемента
        /// </summary>
        Task DeleteAsync(T entity);
    }
}
