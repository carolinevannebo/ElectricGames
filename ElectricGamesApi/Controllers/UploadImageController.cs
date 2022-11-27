#nullable disable

using Microsoft.AspNetCore.Mvc;

namespace ElectricGamesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UploadImageController : ControllerBase
{
    private readonly IWebHostEnvironment _hosting;

    public UploadImageController(IWebHostEnvironment hosting)
    {
        _hosting = hosting;
    }

    [HttpGet] // GET: api/UploadImage
    public ActionResult<PathString> Get()
    {
        return Ok(_hosting.WebRootPath + "/images");
    }

    [HttpPost]
    public IActionResult SaveImage([FromForm] IFormFile file) //mulig du må fjerne [FromForm]
    {
        string wwwrootPath = _hosting.WebRootPath;
        
        /*string type = "";
        if (file.FileName.Contains("game")) { type = "games";}
        else if (file.FileName.Contains("character")) { type = "characters";}
        else if (file.FileName.Contains("location")) { type = "locations";}
        else { type = "";}*/

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
    }
}