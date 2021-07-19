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
    public interface IBaseComplicatedRepository<T, TProperty> : IBaseRepository<T>
    {
    }
}
