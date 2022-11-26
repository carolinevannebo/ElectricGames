using ElectricGamesApi.Logic.Interfaces;
using ElectricGamesApi.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricGamesApi.Logic.Models;

public class Game : IGame
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public GenreEnum Genre { get; set; }
    public ICollection<string>? Platform { get; set; } = new List<string>();
    public string Developer { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    //[InverseProperty("Game")]
    public ICollection<Character> Characters { get; set; } = new List<Character>();
    //[InverseProperty("Game")]
    public ICollection<Location> Locations { get; set; } = new List<Location>();
}