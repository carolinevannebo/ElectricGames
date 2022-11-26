#nullable disable

using ElectricGamesApi.Logic.Models;
using ElectricGamesApi.Logic.Contexts;
using ElectricGamesApi.Logic.Enumerations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ElectricGamesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GameController : ControllerBase
{
    private readonly ElectricGamesContext _context;

    //private readonly IWebHostEnvironment _hosting;

    public GameController(ElectricGamesContext context, IWebHostEnvironment hosting)
    {
        _context = context;
        //_hosting = hosting;
    }

    // GET: api/Game
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> Get() {
        try
        {
            List<Game> games = await _context.Game.ToListAsync();
            
            if (games.Count != 0)
            {
                return Ok(games);
            }
            else
            {
                return NotFound("No games found");
            }
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to retrieve all games");
        }
    }

    // GET: api/Game/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> Get(int id)
    {
        var game = await _context.Game.FindAsync(id);

        return game != null ? Ok(game) : NotFound($"Game with id {id} not found");
    }

    // GET: api/Game/Title/Halo
    [HttpGet("Title/{title}")]
    public async Task<ActionResult<Game>> Get(string title)
    {
        //TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        //var game = await _context.Game.FirstOrDefaultAsync(g => ti.ToLower(g.Title) == ti.ToLower(title));
        var game = await _context.Game.FirstOrDefaultAsync(g => g.Title == title);

        return game != null ? Ok(game) : NotFound($"Game with title {title} not found");
    }

    // GET: api/Game/genre/Action
    [HttpGet("Genre/{genre}")]
    public async Task<ActionResult<IEnumerable<Game>>> Get(GenreEnum genre)
    {
        //TextInfo ti = CultureInfo.CurrentCulture.TextInfo; //-- This is for capitalizing the first letter of the genre, but it doesn't work to compare enums... or does it? check line below
        var games = await _context.Game.Where(g =>
            g.Genre == genre).ToListAsync();
            //ToString(g.Genre) == ToString(genre)).ToListAsync();
        /*var games = await _context.Game.Where(g => 
            ToString((GenreEnum)ti.ToLower((char)g.Genre)) == 
            ToString((GenreEnum)ti.ToLower((char)genre))).ToListAsync();*/

        return games != null ? Ok(games) : NotFound($"No games with genre {genre} found");
    }

    private string ToString(GenreEnum genre)
    {
        return genre.ToString();
    }

    private string ToString(List<string> platform)
    {
        return platform.ToString();
    }

    // GET: api/Game/Platform/PC
    [HttpGet("Platform/{platform}")]
    //[Route("[action]/{platform}")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesByPlatform(string platform)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        var games = await _context.Game.Where(g => 
            ti.ToLower(ToString((List<string>)g.Platform)) == 
            ti.ToLower(platform)).ToListAsync();

        return games != null ? Ok(games) : NotFound($"No games with platform {platform} found");
    }

    // GET: api/Game/Developer/Bungie -- The ones to celebrate!
    [HttpGet("Developer/{developer}")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesByDeveloper(string developer)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        var games = await _context.Game.Where(g => ti.ToLower(g.Developer) == ti.ToLower(developer)).ToListAsync();

        return games != null ? Ok(games) : NotFound($"No games with developer {developer} found");
    }

    // PUT: api/Game/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Game game)
    {
        var gameToUpdate = await _context.Game.FindAsync(id);
        if (gameToUpdate != null)
        {
            gameToUpdate.Title = game.Title;
            gameToUpdate.Genre = game.Genre;
            gameToUpdate.Platform = game.Platform;
            gameToUpdate.Developer = game.Developer;
            gameToUpdate.Publisher = game.Publisher;
            gameToUpdate.ReleaseDate = game.ReleaseDate;
            gameToUpdate.Price = game.Price;
            gameToUpdate.Rating = game.Rating;
            gameToUpdate.Description = game.Description;
            gameToUpdate.Image = game.Image;
            gameToUpdate.Characters = game.Characters;
            gameToUpdate.Locations = game.Locations;
            
            _context.Entry(gameToUpdate).State = EntityState.Modified;

            try
            {
                _context.Game.Update(gameToUpdate); // Snakker med entitystate.modified
                await _context.SaveChangesAsync();
                //Ok($"Game with id {id} updated"); // redundant pga created at action?
                return CreatedAtAction("Get", new { id = gameToUpdate.Id }, gameToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Internal server error while attempting to update game");
            }
        }
        else
        {
            return NotFound($"Game with id {id} not found");
        }
    }

    // POST: api/Game
    [HttpPost]
    public async Task<ActionResult<Game>> Post(Game game)
    {
        var gameToAdd = new Game
        {
            Title = game.Title,
            Genre = game.Genre,
            Platform = game.Platform,
            Developer = game.Developer,
            Publisher = game.Publisher,
            ReleaseDate = game.ReleaseDate,
            Price = game.Price,
            Rating = game.Rating,
            Description = game.Description,
            Image = game.Image,
            Characters = game.Characters,
            Locations = game.Locations
        };

        try
        {
            _context.Game.Add(gameToAdd);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = gameToAdd.Id }, gameToAdd);
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to add game");
        }
    }

    /*[HttpPost]
    public IActionResult SaveImage([FromForm] IFormFile file) //mulig du må fjerne [FromForm]
    {
        string wwwrootPath = _hosting.WebRootPath;
        var absolutePath = Path.Combine($"{wwwrootPath}/images/games/{file.FileName}");
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
    }*/

    // DELETE: api/Game/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var game = await _context.Game.FindAsync(id);
        if (game != null)
        {
            try
            {
                _context.Game.Remove(game);
                await _context.SaveChangesAsync();
                return Ok($"Game with id {id} deleted");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Internal server error while attempting to delete game");
            }
        }
        else
        {
            return NotFound($"Game with id {id} not found");
        }
    }

    private bool GameExists(int id) =>
        _context.Game.Any(e => e.Id == id);
}
