namespace Books.Repositories.Base
{
    /// <summary>
    /// Сложный базовый репозиторий (если с элементом нужно загрузить вложенные элементы)
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public interface IBaseComplicatedRepository<T> : IBaseRepository<T>
    {
    }
}
