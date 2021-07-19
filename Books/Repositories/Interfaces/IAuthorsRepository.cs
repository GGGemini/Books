using Books.Models.Entities;
using Books.Repositories.Base;

namespace Books.Repositories.Interfaces
{
    public interface IAuthorsRepository : IBaseRepository<Author>
    {
    }
}
