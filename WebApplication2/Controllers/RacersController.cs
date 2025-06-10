using Microsoft.AspNetCore.Mvc;
using WebApplication2.Exceptions;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{
    private readonly IDbService _dbService;

    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacers(int id)
    {
        try
        {
            var racer = await _dbService.GetRacers(id);
            return Ok(racer);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
}