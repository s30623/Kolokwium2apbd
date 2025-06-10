using System.Globalization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;

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

    public async Task AddRacer(AddRacerRequestDTO addRacerRequestDTO)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var raceExist = await _context.Races.FirstOrDefaultAsync(r => r.Name == addRacerRequestDTO.RaceName);
            if (raceExist is null)
            {
                throw new NotFoundException("Wyscig z ta nazwa chyab nie istnieje");
            }

            var trackExist = await _context.Tracks.FirstOrDefaultAsync(t => t.Name == addRacerRequestDTO.TrackName);
            if (trackExist is null)
            {
                throw new NotFoundException("Tor o podanzej nazwue nie isntieje");
            }
            foreach (ParticipationRequestDTO racer in addRacerRequestDTO.Participations)
            {
                if (await _context.Racers.FirstOrDefaultAsync(r => r.RacerId == racer.RacerId) is null)
                {
                    throw new NotFoundException($"Racer o id: {racer.RacerId} nie istnieje");
                }
                 _context.RaceParticipations.Add(new RaceParticipation
                 {
                     RacerId = racer.RacerId,
                     Position = racer.Position,
                     FinishTimeInSeconds = racer.FinishTimeInSeconds,
                 });
            }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}