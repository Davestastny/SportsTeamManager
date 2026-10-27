using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>
    /// Vazební entita M:N mezi Match a Player – individuální statistiky hráče v zápase.
    /// </summary>
    [Table("PlayerMatchStat")]
    public class PlayerMatchStat : Entity<int>
    {
        public int MatchId { get; set; }
        public Match? Match { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        [Range(0, 200)]
        public int MinutesPlayed { get; set; }

        [Range(0, 50)]
        public int Goals { get; set; }

        [Range(0, 50)]
        public int Assists { get; set; }

        [Range(0, 2)]
        public int YellowCards { get; set; }

        [Range(0, 1)]
        public int RedCards { get; set; }

        /// <summary>Známka za zápas 1.0–10.0.</summary>
        // (Přesnost decimal(3,1) je nastavena přes Fluent API v PlayerMatchStatConfiguration.)
        [Range(1.0, 10.0)]
        public decimal? Rating { get; set; }
    }
}
