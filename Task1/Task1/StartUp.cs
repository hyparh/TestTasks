using Task1;
using Task1.Data;
using Task1.DTOs;
using Task1.Data.Models;
using Newtonsoft.Json;

// Connection string for MSSQL can be configured at Data/Task1Context class.

var context = new Task1Context();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

string inputJsonAsString = File.ReadAllText("../../../Datasets/input.json");

Console.WriteLine(ImportMovieStars(context, inputJsonAsString));

string ImportMovieStars(Task1Context context, string inputJson)
{
    IEnumerable<MovieStarDto> input = JsonConvert.DeserializeObject<IEnumerable<MovieStarDto>>(inputJson);

    IEnumerable<MovieStar> mappedMovieStars = input
        .Select(x => x.MapToDomainMovieStar())
        .ToList();

    foreach (var user in mappedMovieStars)
    {
        Console.WriteLine(user.Name + " " + user.Surname);
        Console.WriteLine(user.Sex);
        Console.WriteLine(user.Nationality);
        Console.WriteLine(user.Age + " " + "years old");
        Console.WriteLine("");
    }

    context.MovieStars.AddRange(mappedMovieStars);
    context.SaveChanges();

    return null;
}