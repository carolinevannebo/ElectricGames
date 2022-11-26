using ElectricGamesApi.Logic.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricGamesApi.Logic.Models;

public class Character : ICharacter
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    //s[ForeignKey("GameId")]
    //public ICollection<int>? GameId { get; set; } = new List<int>();
    public ICollection<Game> Games { get; set; } = new List<Game>();

}