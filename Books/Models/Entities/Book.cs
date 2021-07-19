using System.Collections.Generic;

namespace Books.Models.Entities
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
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
        /// Авторы книги
        /// </summary>
        public virtual IEnumerable<Author> Authors { get; set; }
    }
}
