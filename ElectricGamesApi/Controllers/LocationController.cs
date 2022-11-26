#nullable disable

using ElectricGamesApi.Logic.Models;
using ElectricGamesApi.Logic.Contexts;
using ElectricGamesApi.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ElectricGamesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LocationController : ControllerBase
{
    private readonly ElectricGamesContext _context;

    //private readonly IWebHostEnvironment _hosting;

    public LocationController(ElectricGamesContext context, IWebHostEnvironment hosting)
    {
        _context = context;
        //_hosting = hosting;
    }

    // GET: api/Location
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> Get() {
        try
        {
            List<Location> locations = await _context.Location.ToListAsync();
            return locations.Count != 0 ? Ok(locations) : NotFound("No locations found");
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to retrieve all locations");
        }
    }

    // GET: api/Location/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> Get(int id)
    {
        var location = await _context.Location.FindAsync(id);
        try
        {
            return location != null ? Ok(location) : NotFound($"Location with id {id} not found");
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to retrieve location by id");
        }
    }

    // GET: api/Location/Name/Newcrest
    [HttpGet("Name/{name}")]
    public async Task<ActionResult<Location>> Get(string name)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        var location = await _context.Location.FirstOrDefaultAsync(l => ti.ToLower(l.Name) == ti.ToLower(name));

        try
        {
            return location != null ? Ok(location) : NotFound($"Location with name {name} not found");
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to retrieve location by name");
        }
    }

    // GET: api/Location/Game/Halo
    [HttpGet("Game/{game}")]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocationByGame(string game)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        var locations = await _context.Location.Where(l => ti.ToLower(l.Game.Title) == ti.ToLower(game)).ToListAsync(); //du la til firstordefault fordi du endret fra en klasse til en icollection

        try
        {
            return locations != null ? Ok(locations) : NotFound($"Locations for game {game} not found");
        }
        catch
        {
            return StatusCode(500, "Internal server error while attempting to retrieve locations by game");
        }
    }

    // PUT: api/Location/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Location location)
    {
        var locationToUpdate = await _context.Location.FindAsync(id);
        if (locationToUpdate != null)
        {
            locationToUpdate.Name = location.Name;
            locationToUpdate.Image = location.Image;
            locationToUpdate.Game = location.Game;

            _context.Entry(location).State = EntityState.Modified;
            try // skal try/catch blokkene være i eller utenfor if-statement??? du har gjort annerledes i de andre controllerne
            {
                _context.Location.Update(locationToUpdate);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = location.Id }, location);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Internal server error while attempting to update location");
            }
        }
        else
        {
            return NotFound($"Location with id {id} not found");
        }
    }

    // POST: api/Location
    [HttpPost]
    public async Task<ActionResult<Location>> Post(Location location)
    {
        var locationToAdd = new Location
        {
            Name = location.Name,
            Image = location.Image,
            Game = location.Game
        };

        try
        {
            _context.Location.Add(locationToAdd);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = locationToAdd.Id }, locationToAdd);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Internal server error while attempting to add a new location");
        }
    }

   /*[HttpPost]
    public IActionResult SaveImage([FromForm] IFormFile file) //mulig du må fjerne [FromForm]
    {
        string wwwrootPath = _hosting.WebRootPath;
        var absolutePath = Path.Combine($"{wwwrootPath}/images/locations/{file.FileName}");
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

    // DELETE: api/Location/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Location>> Delete(int id)
    {
        var location = await _context.Location.FindAsync(id);
        if (location != null)
        {
            try
            {
                _context.Location.Remove(location);
                await _context.SaveChangesAsync();
                return Ok($"Location with id {id} was deleted");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Internal server error while attempting to delete location");
            }
        }
        else
        {
            return NotFound();
        }
    }

    private bool LocationExists(int id) => // kunne kanskje blir lagt i en modul istedenfor å repetere per controller?
        _context.Location.Any(e => e.Id == id);
}