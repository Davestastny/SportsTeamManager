using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>
    /// Vazební entita M:N mezi Training a Player (EF M:N vytváříme explicitně).
    /// Nese docházku a hodnocení výkonu hráče na konkrétním tréninku.
    /// </summary>
    [Table("TrainingAttendance")]
    public class TrainingAttendance : Entity<int>
    {
        public int TrainingId { get; set; }
        public Training? Training { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public AttendanceStatus Status { get; set; }

        /// <summary>Hodnocení výkonu trenérem 1–10 (jen pokud byl hráč přítomen).</summary>
        [Range(1, 10)]
        public int? PerformanceRating { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }
    }
}
