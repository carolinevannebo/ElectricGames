using ElectricGamesApi.Logic.Enumerations;
using ElectricGamesApi.Logic.Models;

namespace ElectricGamesApi.Logic.Interfaces;

public interface IGame
{
    int Id { get; set; }
    string Title { get; set; }
    GenreEnum Genre { get; set; }
    ICollection<string>? Platform { get; set; }
    string Developer { get; set; }
    string Publisher { get; set; }
    DateOnly ReleaseDate { get; set; }
    double Price { get; set; }
    double Rating { get; set; }
    string Description { get; set; }
    string Image { get; set; }
}