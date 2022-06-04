using Task1.DTOs;
using Task1.Data.Models;
using Task1.Models.Enums;
using System.Globalization;

namespace Task1
{
    public static class Mapper
    {
        public static MovieStar MapToDomainMovieStar(this MovieStarDto movieStarDto)
        {
            // Parse the DateOfBirth of type DateTime
            DateTime.TryParseExact(movieStarDto.DateOfBirth, "MMMM dd, yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth);

            // Parse the Sex of type Enum
            Enum.TryParse(typeof(GenderType), movieStarDto.Sex, out object gender);

            var today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            // Go back to the year the person was born in case of a leap year
            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            };

            return new MovieStar
            {
                Name = movieStarDto.Name,
                Sex = (GenderType)gender,
                Surname = movieStarDto.Surname,
                Nationality = movieStarDto.Nationality,
                DateOfBirth = dateOfBirth,
                Age = age
            };
        }
    }
}
