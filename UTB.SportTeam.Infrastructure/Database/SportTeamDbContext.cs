using Microsoft.EntityFrameworkCore;
using UTB.SportTeam.Domain.Entities;

namespace UTB.SportTeam.Infrastructure.Database
{
    /// <summary>
    /// Databázový kontext – v aplikaci reprezentuje databázi.
    /// Každý DbSet odpovídá jedné tabulce.
    /// </summary>
    public class SportTeamDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<TrainingAttendance> TrainingAttendances { get; set; } = null!;
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<PlayerMatchStat> PlayerMatchStats { get; set; } = null!;

        public SportTeamDbContext(DbContextOptions<SportTeamDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Načte všechny třídy implementující IEntityTypeConfiguration<T> ze složky Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportTeamDbContext).Assembly);

            // Seeding – počáteční data
            DatabaseInit databaseInit = new DatabaseInit();
            modelBuilder.Entity<Team>().HasData(databaseInit.CreateTeams());
            modelBuilder.Entity<Player>().HasData(databaseInit.CreatePlayers());
            modelBuilder.Entity<Training>().HasData(databaseInit.CreateTrainings());
            modelBuilder.Entity<TrainingAttendance>().HasData(databaseInit.CreateTrainingAttendances());
            modelBuilder.Entity<Match>().HasData(databaseInit.CreateMatches());
            modelBuilder.Entity<PlayerMatchStat>().HasData(databaseInit.CreatePlayerMatchStats());
        }
    }
}
