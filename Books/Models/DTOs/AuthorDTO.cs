using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs
{
    public class AuthorDTO
    {
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        public string Patronymic { get; set; }
        public int? Age { get; set; }
        public int[] BookIds { get; set; } = new int[] { };
    }
}
