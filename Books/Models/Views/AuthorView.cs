using Books.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models.Views
{
    public class AuthorView
    {
        public AuthorView() { }

        public AuthorView(Author e)
        {
            Id = e.Id;
            Surname = e.Surname;
            Name = e.Name;
            Patronymic = e.Patronymic;
            Age = e.Age;
            Books = e.Books.Select(e => new IdAndName
            {
                Id = e.Id,
                Name = e.Name
            });
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Количество книг
        /// </summary>
        public int NumberOfBooks { get { return Books.Count(); } set { NumberOfBooks = value; } }
        /// <summary>
        /// Книги
        /// </summary>
        public IEnumerable<IdAndName> Books { get; set; }
    }
}
