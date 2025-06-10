using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks  { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>().HasData(new List<Race>
        {
new Race()
{
    RaceId = 1,
    Name = "Race 1",
    Location = "Monaco",
    Date = DateTime.Parse("1999-07-13")
}
        });
        modelBuilder.Entity<Racer>().HasData(new List<Racer>
        {
            new Racer()
            {
                RacerId = 1,
                FirstName = "Tomek",
                LastName = "Kuro",
            }
        });
        modelBuilder.Entity<Track>().HasData(new List<Track>
        {
            new Track()
            {
                TrackId = 1,
                Name = "Grand Track",
                LenghInKm = 15.7,
            }
        });
        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>
        {
            new TrackRace()
            {
                TrackId = 1,
                TrackRaceId = 1,
                Laps = 15,
                
            }
        });
        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>
        {
            new RaceParticipation()
            {
                Position = 1,
                RacerId = 1,
                TrackRaceId = 1,
                FinishTimeInSeconds = 54600,
            }
        });
    }
}