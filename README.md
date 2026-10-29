# UTB.SportTeam – Správa sportovního týmu

Vícevrstvá ASP.NET Core MVC aplikace (.NET 10, EF Core 10, MySQL přes MySql.EntityFrameworkCore).

## Vrstvy

| Projekt | Obsah |
|---|---|
| `UTB.SportTeam.Domain` | Entity (`Team`, `Player`, `Training`, `TrainingAttendance`, `Match`, `PlayerMatchStat`), enumy, `IEntity<TKey>`, generické `IRepository<T, TKey>` |
| `UTB.SportTeam.Infrastructure` | `SportTeamDbContext`, Fluent API konfigurace vazeb, seed data (`DatabaseInit`), generický `Repository<T, TKey>`, migrace |
| `UTB.SportTeam.Application` | Vrstva pro aplikační služby (budou pracovat přes `IRepository`) |
| `UTB.SportTeam.Web` | ASP.NET Core MVC: `Startup.cs` (registrace DbContextu a Repository), `wwwroot`, `Controllers`, `Models/ViewModel`, `Views` |

Závislosti: Web → Application, Infrastructure, Domain; Infrastructure → Domain; Application → Domain.

## Spuštění

1. Zkontrolujte connection string v `UTB.SportTeam.Web/appsettings.json`
   (výchozí: `server=localhost;database=UTB.SportTeam;user=root;password=rootroot`).
2. Ve Visual Studiu nastavte `UTB.SportTeam.Web` jako Startup Project.
3. Otevřete **Package Manager Console** (Konzola správce balíčků), jako *Default project* vyberte
   `UTB.SportTeam.Infrastructure` a spusťte:

   ```
   Update-Database
   ```

   Vytvoří se databáze `UTB.SportTeam` se 6 tabulkami a ukázkovými daty (1 tým, 5 hráčů, 2 tréninky, 2 zápasy).
4. Spusťte aplikaci (F5).

Přes .NET CLI (ze složky solution):

```
dotnet tool install --global dotnet-ef --version "10.*"
dotnet ef database update --project UTB.SportTeam.Infrastructure --startup-project UTB.SportTeam.Web
```

## Nová migrace po změně entit

```
Add-Migration NazevMigrace
Update-Database
```

