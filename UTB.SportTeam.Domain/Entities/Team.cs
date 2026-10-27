using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>Sportovní tým – hlavní (primární) entita celé aplikace.</summary>
    [Table("Team")]
    public class Team : Entity<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Sport { get; set; } = string.Empty;

        /// <summary>Věková kategorie / soutěžní úroveň, např. "Muži A", "U19".</summary>
        [StringLength(50)]
        public string? Category { get; set; }

        [StringLength(100)]
        public string? CoachName { get; set; }

        [Range(1850, 2100)]
        public int? FoundedYear { get; set; }

        // Navigační property (kolekce) – 1:N vazby
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Training> Trainings { get; set; } = new List<Training>();
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
