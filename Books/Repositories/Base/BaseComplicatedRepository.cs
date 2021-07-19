using Books.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Books.Repositories.Base
{
    /// <summary>
    /// Сложный базовый репозиторий (если с элементом нужно загрузить вложенные элементы)
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    /// <typeparam name="TProperty">Вложенная сущность</typeparam>
    public class BaseComplicatedRepository<T> : BaseRepository<T>, IBaseComplicatedRepository<T>
        where T : class
    {
        public BaseComplicatedRepository(AppDbContext context) : base(context)
        {
            _dbSet.Include(typeof(T).GetProperties().LastOrDefault().Name).Load(); // загружаем контекст данных с вложенными элементами
        }
    }
}
