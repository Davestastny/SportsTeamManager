using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.SportTeam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CoachName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FoundedYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Opponent = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IsHomeMatch = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Competition = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    GoalsFor = table.Column<int>(type: "int", nullable: true),
                    GoalsAgainst = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Focus = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayerMatchStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatchStat_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatchStat_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrainingAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PerformanceRating = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingAttendance_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingAttendance_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Category", "CoachName", "FoundedYear", "Name", "Sport" },
                values: new object[] { 1, "Muži A", "Petr Novák", 1998, "FC Zlín Lions", "Fotbal" });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "Id", "Competition", "GoalsAgainst", "GoalsFor", "IsHomeMatch", "Location", "MatchDate", "Opponent", "TeamId" },
                values: new object[,]
                {
                    { 1, "Krajský přebor", 1, 3, true, "Stadion Letná, Zlín", new DateTime(2026, 10, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), "SK Otrokovice", 1 },
                    { 2, "Krajský přebor", null, null, false, "Vsetín", new DateTime(2026, 10, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), "FC Vsetín", 1 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "IsActive", "JerseyNumber", "LastName", "Position", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", true, 1, "Dvořák", 1, 1 },
                    { 2, new DateTime(1999, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomáš", true, 4, "Svoboda", 2, 1 },
                    { 3, new DateTime(2000, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lukáš", true, 8, "Procházka", 3, 1 },
                    { 4, new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", true, 10, "Kučera", 3, 1 },
                    { 5, new DateTime(1998, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ondřej", true, 9, "Veselý", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "DurationMinutes", "Focus", "Location", "Note", "StartTime", "TeamId" },
                values: new object[,]
                {
                    { 1, 90, "Kondice a presink", "Hřiště Vršava", null, new DateTime(2026, 10, 13, 17, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 75, "Standardní situace", "Hřiště Vršava", "Příprava na zápas s Otrokovicemi", new DateTime(2026, 10, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "PlayerMatchStat",
                columns: new[] { "Id", "Assists", "Goals", "MatchId", "MinutesPlayed", "PlayerId", "Rating", "RedCards", "YellowCards" },
                values: new object[,]
                {
                    { 1, 0, 0, 1, 90, 1, 7.0m, 0, 0 },
                    { 2, 1, 0, 1, 90, 2, 6.5m, 0, 1 },
                    { 3, 0, 0, 1, 65, 3, 6.0m, 0, 0 },
                    { 4, 2, 1, 1, 90, 4, 8.0m, 0, 0 },
                    { 5, 0, 2, 1, 80, 5, 8.5m, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "TrainingAttendance",
                columns: new[] { "Id", "Note", "PerformanceRating", "PlayerId", "Status", "TrainingId" },
                values: new object[,]
                {
                    { 1, null, 7, 1, 1, 1 },
                    { 2, null, 6, 2, 1, 1 },
                    { 3, "Zkouška ve škole", null, 3, 3, 1 },
                    { 4, null, 8, 4, 1, 1 },
                    { 5, "Natažený sval", null, 5, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId",
                table: "Match",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStat_MatchId_PlayerId",
                table: "PlayerMatchStat",
                columns: new[] { "MatchId", "PlayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStat_PlayerId",
                table: "PlayerMatchStat",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TeamId",
                table: "Training",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAttendance_PlayerId",
                table: "TrainingAttendance",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAttendance_TrainingId_PlayerId",
                table: "TrainingAttendance",
                columns: new[] { "TrainingId", "PlayerId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMatchStat");

            migrationBuilder.DropTable(
                name: "TrainingAttendance");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
