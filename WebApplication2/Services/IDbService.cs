using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;

namespace WebApplication2.Services;

public interface IDbService
{
    public Task<RacerResultDTO> GetRacers(int id);
}