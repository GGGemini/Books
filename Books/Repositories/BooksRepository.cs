using Books.Helpers;
using Books.Models;
using Books.Models.Entities;
using Books.Repositories.Base;
using Books.Repositories.Context;
using Books.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Repositories
{
    public class BooksRepository : BaseComplicatedRepository<Book, Author>, IBooksRepository
    {
        public BooksRepository(AppDbContext context) : base(context)
        {
        }
    }
}
