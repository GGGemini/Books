using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "Не указано название книги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано количество страниц")]
        public int NumberOfPages { get; set; }
        public int[] AuthorIds { get; set; } = new int[] { };
    }
}
