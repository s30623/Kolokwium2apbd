using System.Globalization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;

namespace WebApplication2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<RacerResultDTO> GetRacers(int id)
    {
         var result = await _context.Racers.Select(e => new RacerResultDTO
         {
             FirstName = e.FirstName,
             LastName = e.LastName,
             RacerId = e.RacerId,
             Participations = e.RaceParticipations.Select(a => new ParticipationDTO
             {
                 FinishTimeInSeconds = a.FinishTimeInSeconds,
                 Laps = a.TrackRace.Laps,
                 Position = a.Position,
             }).ToList(),
         }).FirstOrDefaultAsync(e => e.RacerId == id);
         if (result is null)
         {
             throw new NotFoundException();
         }
            return result;
    }
}