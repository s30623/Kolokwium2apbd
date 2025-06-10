using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[Table("Track")]
public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [Precision(5,2)]
    public double LenghInKm { get; set; }

    public ICollection<TrackRace> TrackRace { get; set; } = null!;
}