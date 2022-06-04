using Task1.Common;
using Task1.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Task1.Data.Models
{
    using static GlobalConstants;

    public class MovieStar
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(SurnameMaxLength)]
        public string Surname { get; set; }

        public GenderType Sex { get; set; }

        [Required]
        [MaxLength(NationalityLength)]
        public string Nationality { get; set; }

        public int Age { get; set; }
    }
}
