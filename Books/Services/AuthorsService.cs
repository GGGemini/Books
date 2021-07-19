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
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IBooksRepository _booksRepository;

        public AuthorsService(IAuthorsRepository authorsRepository,
            IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
            _authorsRepository = authorsRepository;
        }

        public async Task<IEnumerable<AuthorView>> Get()
        {
            IEnumerable<Author> entities = await _authorsRepository.GetAsync();

            IEnumerable<AuthorView> views = entities.Select(e => new AuthorView(e));

            return views;
        }

        public async Task<AuthorView> GetById(int id)
        {
            Author entity = await _authorsRepository.FirstOrDefaultAsync(b => b.Id == id);

            AuthorView view = new AuthorView(entity);

            return view;
        }

        public async Task<AuthorView> Create(AuthorDTO dto)
        {
            Author entity = new Author
            {
                Surname = dto.Surname,
                Name = dto.Name,
                Patronymic = dto.Patronymic,
                Age = dto.Age,
                Books = await _booksRepository.CheckCountAndGet(a => dto.BookIds.Contains(a.Id), dto.BookIds.Length)
            };

            await _authorsRepository.CreateAsync(entity);

            AuthorView view = new AuthorView(entity);

            return view;
        }

        public async Task<AuthorView> Update(int id, AuthorDTO dto)
        {
            Author entity = await _authorsRepository.GetByIdAsync(id);

            entity.Surname = dto.Surname;
            entity.Name = dto.Name;
            entity.Patronymic = dto.Patronymic;
            entity.Age = dto.Age;
            entity.Books = await _booksRepository.CheckCountAndGet(a => dto.BookIds.Contains(a.Id), dto.BookIds.Length);

            await _authorsRepository.UpdateAsync(entity);

            AuthorView view = new AuthorView(entity);

            return view;
        }

        public async Task Delete(int id)
        {
            Author entity = await _authorsRepository.GetByIdAsync(id);

            await _authorsRepository.DeleteAsync(entity);
        }
    }
}
