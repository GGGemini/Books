using Books.Models.Entities;
using Books.Repositories.Base;
using Books.Repositories.Context;
using Books.Repositories.Interfaces;

namespace Books.Repositories
{
    public class AuthorsRepository : BaseComplicatedRepository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
