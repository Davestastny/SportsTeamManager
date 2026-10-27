using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>Zápas týmu proti soupeři. Skóre je null, dokud se zápas neodehraje.</summary>
    [Table("Match")]
    public class Match : Entity<int>
    {
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        [Required]
        [StringLength(100)]
        public string Opponent { get; set; } = string.Empty;

        public DateTime MatchDate { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        public bool IsHomeMatch { get; set; }

        [StringLength(100)]
        public string? Competition { get; set; }

        [Range(0, 999)]
        public int? GoalsFor { get; set; }

        [Range(0, 999)]
        public int? GoalsAgainst { get; set; }

        public ICollection<PlayerMatchStat> PlayerStats { get; set; } = new List<PlayerMatchStat>();

        [NotMapped]
        public bool IsPlayed => GoalsFor.HasValue && GoalsAgainst.HasValue;
    }
}
