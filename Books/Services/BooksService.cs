using Books.Models.DTOs;
using Books.Models.Entities;
using Books.Models.Views;
using Books.Repositories.Interfaces;
using Books.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IAuthorsRepository _authorsRepository;

        public BooksService(IBooksRepository booksRepository,
            IAuthorsRepository authorsRepository)
        {
            _booksRepository = booksRepository;
            _authorsRepository = authorsRepository;
        }

        public async Task<IEnumerable<BookView>> Get()
        {
            IEnumerable<Book> entities = await _booksRepository.GetAsync();

            IEnumerable<BookView> views = entities.Select(e => new BookView(e));

            return views;
        }

        public async Task<BookView> GetById(int id)
        {
            Book entity = await _booksRepository.FirstOrDefaultAsync(b => b.Id == id);

            BookView view = new BookView(entity);

            return view;
        }

        public async Task<BookView> Create(BookDTO dto)
        {
            Book entity = new Book
            {
                Name = dto.Name,
                NumberOfPages = dto.NumberOfPages,
                Authors = await _authorsRepository.CheckCountAndGet(a => dto.AuthorIds.Contains(a.Id), dto.AuthorIds.Length)
            };

            await _booksRepository.CreateAsync(entity);

            BookView view = new BookView(entity);

            return view;
        }

        public async Task<BookView> Update(int id, BookDTO dto)
        {
            Book entity = await _booksRepository.GetByIdAsync(id);

            entity.Name = dto.Name;
            entity.NumberOfPages = dto.NumberOfPages;
            entity.Authors = await _authorsRepository.CheckCountAndGet(a => dto.AuthorIds.Contains(a.Id), dto.AuthorIds.Length);

            await _booksRepository.UpdateAsync(entity);

            BookView view = new BookView(entity);

            return view;
        }

        public async Task Delete(int id)
        {
            Book entity = await _booksRepository.GetByIdAsync(id);

            await _booksRepository.DeleteAsync(entity);
        }
    }
}
