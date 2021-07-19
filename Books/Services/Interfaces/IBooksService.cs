using Books.Models.DTOs;
using Books.Models.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Services.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<BookView>> Get();
        Task<BookView> GetById(int id);
        Task<BookView> Create(BookDTO dto);
        Task<BookView> Update(int id, BookDTO dto);
        Task Delete(int id);
    }
}
