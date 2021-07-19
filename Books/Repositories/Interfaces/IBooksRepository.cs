using Books.Models;
using Books.Models.Entities;
using Books.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Repositories.Interfaces
{
    public interface IBooksRepository : IBaseComplicatedRepository<Book, Author>
    {
    }
}
