using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api/track-racers")]
public class Track_RacersController : ControllerBase
{
    private readonly IDbService _dbService;

    public Track_RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddRacer(AddRacerRequestDTO addRacerRequestDto)
    {
        try
        {
            await _dbService.AddRacer(addRacerRequestDto);
            return Ok("Racers added");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        
    }
}