//using ElectricGamesApi.Logic.Models;

namespace ElectricGamesApi.Logic.Interfaces;

public interface ICharacter 
{
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Image { get; set; }
    //ICollection<int> GameId { get; set; }
}