using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricGamesApi.Logic.Models;

public class CharacterGame
{
    public int CharacterId { get; set; }
    public Character? Character { get; set; } //= new Character();
    public int GameId { get; set; }
    public ICollection<Game>? Game { get; set; } //= new Game();
}