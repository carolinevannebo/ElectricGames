#nullable disable

using ElectricGamesApi.Logic.Models;
using ElectricGamesApi.Logic.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ElectricGamesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CharacterController : ControllerBase 
{
    private readonly ElectricGamesContext _context;

    private readonly IWebHostEnvironment _hosting;

    public CharacterController(ElectricGamesContext context, IWebHostEnvironment hosting)
    {
        _context = context;
        _hosting = hosting;
    }

    // GET: api/Character
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Character>>> GetAllCharacters()
    {
        Character[] characters = await _context.Character.ToArrayAsync();

        if (characters.Length != 0)
        {
            return Ok(characters);
        }
        else
        {
            return NotFound("No characters found");
        }
    }

    // GET: api/Character/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        var character = await _context.Character.FindAsync(id);

        return character != null ? Ok(character) : NotFound($"Character with id {id} not found");
    }

    // GET: api/Character/Name/Link
    [HttpGet("Name/{name}")]
    public async Task<ActionResult<Character>> GetCharacterByName(string name)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        var character = await _context.Character.FirstOrDefaultAsync(c => ti.ToLower(c.Name) == ti.ToLower(name));

        return character != null ? Ok(character) : NotFound($"Character with the name {name} not found");
    }

    // GET: api/Character/Game/Zelda
    [HttpGet("Game/{game}")]
    public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByGame(string game)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        var gameToReference = await _context.Game.FirstOrDefaultAsync(g => ti.ToLower(g.Title) == ti.ToLower(game));
        var characters = await _context.Character.Where(c => c.Games.Contains(gameToReference)).ToArrayAsync();

        if (gameToReference != null)
        {
            if (characters.Length != 0)
            {
                try
                {
                    return Ok(characters);
                }
                catch
                {
                    return StatusCode(500, "Internal server error while trying to get characters by game");
                }
            }
            else
            {
                return NotFound($"No characters found for the game {game}");
            }
        }
        else
        {
            return NotFound($"Game with the title {game} not found");
        }
    }

    // POST: api/Character
    [HttpPost]
    public async Task<ActionResult<Character>> CreateCharacter(Character character)
    {
        var characterToAdd = new Character
        {
            //Id = character.Id, // Id is auto generated???
            Name = character.Name,
            Description = character.Description,
            Image = character.Image,
            Games = character.Games
        };

        try
        {
            _context.Character.Add(characterToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacterById), new { id = characterToAdd.Id }, characterToAdd);
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to create character");
        }
        
    }

    [HttpPost]
    public IActionResult SaveImage([FromForm] IFormFile file) //mulig du må fjerne [FromForm]
    {
        string wwwrootPath = _hosting.WebRootPath;
        var absolutePath = Path.Combine($"{wwwrootPath}/images/characters/{file.FileName}");
        using (var fileStream = new FileStream(absolutePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        try
        {
            return Ok(new { file.FileName });
        }
        catch
        {
            return BadRequest("File upload failed");
        }
    }

    // PUT: api/Character/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCharacter(int id, Character character)
    {
        if (id != character.Id)
        {
            return BadRequest($"Character with id {id} does not exist");
        }
        
        try
        {
            var characterToUpdate = await _context.Character.FindAsync(id);

            if (characterToUpdate != null)
            {
                characterToUpdate.Name = character.Name;
                characterToUpdate.Description = character.Description;
                characterToUpdate.Image = character.Image;
                characterToUpdate.Games = character.Games;

                _context.Entry(characterToUpdate).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCharacterById), new { id = characterToUpdate.Id }, characterToUpdate);

        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(500, "Internal server error while attempting to update character");
        }
    }

    // DELETE: api/Character/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        var characterToDelete = await _context.Character.FindAsync(id);

        if (characterToDelete != null)
        {
            try
            {
                _context.Character.Remove(characterToDelete);
                await _context.SaveChangesAsync();
                return Ok($"Character with id {id} deleted");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Internal server error while attempting to delete character");
            }
        }
        else
        {
            return NotFound($"Character with id {id} not found");
        }
    }

    private bool CharacterExists(int id) =>
        _context.Character.Any(e => e.Id == id);
}