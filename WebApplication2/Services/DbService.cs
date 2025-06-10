using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication2.Data;
using WebApplication2.DTOs;

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
        // var result = _context
        
        var a =  new RacerResultDTO();
        return a;
    }
}