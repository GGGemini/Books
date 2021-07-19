using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int? Age { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
