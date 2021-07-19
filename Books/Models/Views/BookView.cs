using Books.Helpers;
using Books.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Books.Models.Views
{
    public class BookView
    {
        public BookView() { }

        public BookView(Book e)
        {
            Id = e.Id;
            Name = e.Name;
            NumberOfPages = e.NumberOfPages;
            Authors = e.Authors.Select(e => new IdAndName
            {
                Id = e.Id,
                Name = StringHelper.GetShortName(e.Surname, e.Name, e.Patronymic)
            });
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя книги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int NumberOfPages { get; set; }
        /// <summary>
        /// Количество авторов
        /// </summary>
        public int NumberOfAuthors { get { return Authors.Count(); } set { NumberOfAuthors = value; } }
        /// <summary>
        /// Авторы книг
        /// </summary>
        public IEnumerable<IdAndName> Authors { get; set; }
    }
}
