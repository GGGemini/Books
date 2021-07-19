using Books.Models.Entities;
using Books.Repositories.Base;
using Books.Repositories.Context;
using Books.Repositories.Interfaces;

namespace Books.Repositories
{
    public class BooksRepository : BaseComplicatedRepository<Book>, IBooksRepository
    {
        public BooksRepository(AppDbContext context) : base(context)
        {
        }
    }
}
