using UTB.SportTeam.Domain.Entities;

namespace UTB.SportTeam.Infrastructure.Database
{
    /// <summary>
    /// Počáteční (seed) data – vkládají se do DB přes migraci (HasData).
    /// U HasData je nutné zadat Id i cizí klíče ručně a nepoužívat DateTime.Now.
    /// </summary>
    internal class DatabaseInit
    {
        public List<Team> CreateTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "FC Zlín Lions",
                    Sport = "Fotbal",
                    Category = "Muži A",
                    CoachName = "Petr Novák",
                    FoundedYear = 1998
                }
            };
        }

        public List<Player> CreatePlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Dvořák",
                    DateOfBirth = new DateTime(2001, 3, 14, 0, 0, 0),
                    JerseyNumber = 1,
                    Position = PlayerPosition.Goalkeeper,
                    IsActive = true,
                    TeamId = 1
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Tomáš",
                    LastName = "Svoboda",
                    DateOfBirth = new DateTime(1999, 7, 2, 0, 0, 0),
                    JerseyNumber = 4,
                    Position = PlayerPosition.Defender,
                    IsActive = true,
                    TeamId = 1
                },
                new Player
                {
                    Id = 3,
                    FirstName = "Lukáš",
                    LastName = "Procházka",
                    DateOfBirth = new DateTime(2000, 11, 21, 0, 0, 0),
                    JerseyNumber = 8,
                    Position = PlayerPosition.Midfielder,
                    IsActive = true,
                    TeamId = 1
                },
                new Player
                {
                    Id = 4,
                    FirstName = "Martin",
                    LastName = "Kučera",
                    DateOfBirth = new DateTime(2002, 5, 9, 0, 0, 0),
                    JerseyNumber = 10,
                    Position = PlayerPosition.Midfielder,
                    IsActive = true,
                    TeamId = 1
                },
                new Player
                {
                    Id = 5,
                    FirstName = "Ondřej",
                    LastName = "Veselý",
                    DateOfBirth = new DateTime(1998, 1, 30, 0, 0, 0),
                    JerseyNumber = 9,
                    Position = PlayerPosition.Forward,
                    IsActive = true,
                    TeamId = 1
                }
            };
        }

        public List<Training> CreateTrainings()
        {
            return new List<Training>
            {
                new Training
                {
                    Id = 1,
                    TeamId = 1,
                    StartTime = new DateTime(2026, 10, 13, 17, 30, 0),
                    DurationMinutes = 90,
                    Location = "Hřiště Vršava",
                    Focus = "Kondice a presink",
                    Note = null
                },
                new Training
                {
                    Id = 2,
                    TeamId = 1,
                    StartTime = new DateTime(2026, 10, 15, 17, 30, 0),
                    DurationMinutes = 75,
                    Location = "Hřiště Vršava",
                    Focus = "Standardní situace",
                    Note = "Příprava na zápas s Otrokovicemi"
                }
            };
        }

        public List<TrainingAttendance> CreateTrainingAttendances()
        {
            return new List<TrainingAttendance>
            {
                new TrainingAttendance
                {
                    Id = 1,
                    TrainingId = 1,
                    PlayerId = 1,
                    Status = AttendanceStatus.Present,
                    PerformanceRating = 7,
                    Note = null
                },
                new TrainingAttendance
                {
                    Id = 2,
                    TrainingId = 1,
                    PlayerId = 2,
                    Status = AttendanceStatus.Present,
                    PerformanceRating = 6,
                    Note = null
                },
                new TrainingAttendance
                {
                    Id = 3,
                    TrainingId = 1,
                    PlayerId = 3,
                    Status = AttendanceStatus.Excused,
                    PerformanceRating = null,
                    Note = "Zkouška ve škole"
                },
                new TrainingAttendance
                {
                    Id = 4,
                    TrainingId = 1,
                    PlayerId = 4,
                    Status = AttendanceStatus.Present,
                    PerformanceRating = 8,
                    Note = null
                },
                new TrainingAttendance
                {
                    Id = 5,
                    TrainingId = 1,
                    PlayerId = 5,
                    Status = AttendanceStatus.Injured,
                    PerformanceRating = null,
                    Note = "Natažený sval"
                }
            };
        }

        public List<Match> CreateMatches()
        {
            return new List<Match>
            {
                new Match
                {
                    Id = 1,
                    TeamId = 1,
                    Opponent = "SK Otrokovice",
                    MatchDate = new DateTime(2026, 10, 18, 15, 0, 0),
                    Location = "Stadion Letná, Zlín",
                    IsHomeMatch = true,
                    Competition = "Krajský přebor",
                    GoalsFor = 3,
                    GoalsAgainst = 1
                },
                new Match
                {
                    Id = 2,
                    TeamId = 1,
                    Opponent = "FC Vsetín",
                    MatchDate = new DateTime(2026, 10, 25, 15, 0, 0),
                    Location = "Vsetín",
                    IsHomeMatch = false,
                    Competition = "Krajský přebor",
                    GoalsFor = null,
                    GoalsAgainst = null
                }
            };
        }

        public List<PlayerMatchStat> CreatePlayerMatchStats()
        {
            return new List<PlayerMatchStat>
            {
                new PlayerMatchStat
                {
                    Id = 1,
                    MatchId = 1,
                    PlayerId = 1,
                    MinutesPlayed = 90,
                    Goals = 0,
                    Assists = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    Rating = 7.0m
                },
                new PlayerMatchStat
                {
                    Id = 2,
                    MatchId = 1,
                    PlayerId = 2,
                    MinutesPlayed = 90,
                    Goals = 0,
                    Assists = 1,
                    YellowCards = 1,
                    RedCards = 0,
                    Rating = 6.5m
                },
                new PlayerMatchStat
                {
                    Id = 3,
                    MatchId = 1,
                    PlayerId = 3,
                    MinutesPlayed = 65,
                    Goals = 0,
                    Assists = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    Rating = 6.0m
                },
                new PlayerMatchStat
                {
                    Id = 4,
                    MatchId = 1,
                    PlayerId = 4,
                    MinutesPlayed = 90,
                    Goals = 1,
                    Assists = 2,
                    YellowCards = 0,
                    RedCards = 0,
                    Rating = 8.0m
                },
                new PlayerMatchStat
                {
                    Id = 5,
                    MatchId = 1,
                    PlayerId = 5,
                    MinutesPlayed = 80,
                    Goals = 2,
                    Assists = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    Rating = 8.5m
                }
            };
        }
    }
}
