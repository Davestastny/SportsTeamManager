using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>Naplánovaný (nebo proběhlý) trénink týmu.</summary>
    [Table("Training")]
    public class Training : Entity<int>
    {
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        public DateTime StartTime { get; set; }

        [Range(10, 300)]
        public int DurationMinutes { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        /// <summary>Zaměření tréninku, např. "Kondice", "Standardní situace".</summary>
        [StringLength(200)]
        public string? Focus { get; set; }

        public string? Note { get; set; }

        public ICollection<TrainingAttendance> Attendances { get; set; } = new List<TrainingAttendance>();
    }
}
