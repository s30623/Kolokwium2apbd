using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Track_Race")]
public class TrackRace

{
    [Key]
    public int TrackRaceId { get; set; }
    [ForeignKey("Track")]
    public int TrackId { get; set; }
    [ForeignKey("Race")]
    public int RaceId { get; set; }
    public int Laps { get; set; }
    public int? BestTimeInSeconds { get; set; }
    public Race Race { get; set; } = null!;
    public List<RaceParticipation> RaceParticipation { get; set; } = null!;
    public Track Track { get; set; } = null!;
}