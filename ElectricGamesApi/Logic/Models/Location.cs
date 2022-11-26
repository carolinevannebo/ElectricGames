using ElectricGamesApi.Logic.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricGamesApi.Logic.Models;
//[Microsoft.EntityFrameworkCore.Owned]
public class Location : ILocation
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    //IFormFile ILocation.Image { get; set; } = null!;
    public string Image { get; set; } = "";
    //public string[] Game { get; set; } = new string[] { };
    //public ICollection<Game> Game { get; set; } = new List<Game>();
    [ForeignKey("GameId")]
    public int? GameId { get; set; }
    //[Required]
    public Game? Game { get; set; } //= new Game();
    //public ICollection<Game> Game { get; set; } = new List<Game>();
}