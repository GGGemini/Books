using Books.Models.DTOs;
using Books.Models.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Services.Interfaces
{
    public interface IAuthorsService
    {
        Task<IEnumerable<AuthorView>> Get();
        Task<AuthorView> GetById(int id);
        Task<AuthorView> Create(AuthorDTO dto);
        Task<AuthorView> Update(int id, AuthorDTO dto);
        Task Delete(int id);
    }
}
