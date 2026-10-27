namespace UTB.SportTeam.Domain.Entities
{
    /// <summary>Herní post hráče (ukládá se do DB jako int).</summary>
    public enum PlayerPosition
    {
        Goalkeeper = 1,
        Defender = 2,
        Midfielder = 3,
        Forward = 4
    }

    /// <summary>Stav účasti hráče na tréninku (ukládá se do DB jako int).</summary>
    public enum AttendanceStatus
    {
        Present = 1,
        Absent = 2,
        Excused = 3,
        Injured = 4
    }
}
