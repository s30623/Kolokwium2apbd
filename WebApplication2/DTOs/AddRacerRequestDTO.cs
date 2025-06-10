namespace WebApplication2.DTOs;

public class AddRacerRequestDTO
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<ParticipationRequestDTO> Participations { get; set; }
}

public class ParticipationRequestDTO
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}