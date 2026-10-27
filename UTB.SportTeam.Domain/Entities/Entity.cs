using System.ComponentModel.DataAnnotations;
using UTB.SportTeam.Domain.Entities.Interfaces;

namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>
    /// Abstraktní předek entit s celočíselným primárním klíčem.
    /// </summary>
    public abstract class Entity<TKey> : IEntity<TKey> where TKey : notnull
    {
        [Key]
        public TKey Id { get; set; } = default!;
    }
}
