using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTB.SportTeam.Domain.Entities;

namespace UTB.SportTeam.Infrastructure.Database.Configurations
{
    // Fluent API konfigurace vazeb a omezení, která nejdou (nebo nejdou pěkně) zapsat atributy.
    // Délky řetězců a povinnost polí jsou v entitách přes Data Annotations.

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasOne(p => p.Team)
                   .WithMany(t => t.Players)
                   .HasForeignKey(p => p.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasOne(t => t.Team)
                   .WithMany(t => t.Trainings)
                   .HasForeignKey(t => t.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TrainingAttendanceConfiguration : IEntityTypeConfiguration<TrainingAttendance>
    {
        public void Configure(EntityTypeBuilder<TrainingAttendance> builder)
        {
            builder.HasOne(a => a.Training)
                   .WithMany(t => t.Attendances)
                   .HasForeignKey(a => a.TrainingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Player)
                   .WithMany(p => p.TrainingAttendances)
                   .HasForeignKey(a => a.PlayerId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Jeden hráč může mít na jednom tréninku jen jeden záznam docházky
            builder.HasIndex(a => new { a.TrainingId, a.PlayerId }).IsUnique();
        }
    }

    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(m => m.Team)
                   .WithMany(t => t.Matches)
                   .HasForeignKey(m => m.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PlayerMatchStatConfiguration : IEntityTypeConfiguration<PlayerMatchStat>
    {
        public void Configure(EntityTypeBuilder<PlayerMatchStat> builder)
        {
            builder.Property(s => s.Rating).HasPrecision(3, 1);

            builder.HasOne(s => s.Match)
                   .WithMany(m => m.PlayerStats)
                   .HasForeignKey(s => s.MatchId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Player)
                   .WithMany(p => p.MatchStats)
                   .HasForeignKey(s => s.PlayerId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Jeden hráč má v jednom zápase jen jeden řádek statistik
            builder.HasIndex(s => new { s.MatchId, s.PlayerId }).IsUnique();
        }
    }
}
