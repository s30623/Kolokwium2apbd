using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class RacerResultDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ParticipationDTO> Participations { get; set; }
    
}

public class ParticipationDTO
{
    public RaceDTO Race { get; set; }
    public TrackDTO Track { get; set; }
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly Date { get; set; }
}

public class TrackDTO
{
    public string Name { get; set; }
    public double LenghInKim {get; set;}
}