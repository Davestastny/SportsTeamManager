using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>Hráč – patří právě do jednoho týmu.</summary>
    [Table("Player")]
    public class Player : Entity<int>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [Range(1, 99)]
        public int JerseyNumber { get; set; }

        public PlayerPosition Position { get; set; }

        /// <summary>Neaktivní hráč (odchod, ukončení kariéry) zůstává v DB kvůli historii statistik.</summary>
        public bool IsActive { get; set; } = true;

        // Cizí klíč + navigační property (reference)
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        public ICollection<TrainingAttendance> TrainingAttendances { get; set; } = new List<TrainingAttendance>();
        public ICollection<PlayerMatchStat> MatchStats { get; set; } = new List<PlayerMatchStat>();

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
