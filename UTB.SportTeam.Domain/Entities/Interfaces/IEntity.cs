namespace UTB.SportTeam.Domain.Entities.Interfaces
{
    /// <summary>
    /// Společné rozhraní pro všechny entity – každá entita má primární klíč Id.
    /// Díky němu může generický Repository pracovat s libovolnou entitou.
    /// </summary>
    public interface IEntity<TKey> where TKey : notnull
    {
        TKey Id { get; set; }
    }
}
