using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTB.SportTeam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoachName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FoundedYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Focus = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Opponent = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MatchDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHomeMatch = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Competition = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrainingAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PerformanceRating = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayerMatchStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Name", "Sport", "Category", "CoachName", "FoundedYear" },
                values: new object[] { 1, "FC Zlín Lions", "Fotbal", "Muži A", "Petr Novák", 1998 });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "FirstName", "LastName", "DateOfBirth", "JerseyNumber", "Position", "IsActive", "TeamId" },
                values: new object[,]
                {
                    { 1, "Jan", "Dvořák", new DateTime(2001, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, true, 1 },
                    { 2, "Tomáš", "Svoboda", new DateTime(1999, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, true, 1 },
                    { 3, "Lukáš", "Procházka", new DateTime(2000, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 3, true, 1 },
                    { 4, "Martin", "Kučera", new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 3, true, 1 },
                    { 5, "Ondřej", "Veselý", new DateTime(1998, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 4, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "TeamId", "StartTime", "DurationMinutes", "Location", "Focus", "Note" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 10, 13, 17, 30, 0, 0, DateTimeKind.Unspecified), 90, "Hřiště Vršava", "Kondice a presink", null },
                    { 2, 1, new DateTime(2026, 10, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), 75, "Hřiště Vršava", "Standardní situace", "Příprava na zápas s Otrokovicemi" }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "Id", "TeamId", "Opponent", "MatchDate", "Location", "IsHomeMatch", "Competition", "GoalsFor", "GoalsAgainst" },
                values: new object[,]
                {
                    { 1, 1, "SK Otrokovice", new DateTime(2026, 10, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), "Stadion Letná, Zlín", true, "Krajský přebor", 3, 1 },
                    { 2, 1, "FC Vsetín", new DateTime(2026, 10, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), "Vsetín", false, "Krajský přebor", null, null }
                });

            migrationBuilder.InsertData(
                table: "TrainingAttendance",
                columns: new[] { "Id", "TrainingId", "PlayerId", "Status", "PerformanceRating", "Note" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 7, null },
                    { 2, 1, 2, 1, 6, null },
                    { 3, 1, 3, 3, null, "Zkouška ve škole" },
                    { 4, 1, 4, 1, 8, null },
                    { 5, 1, 5, 4, null, "Natažený sval" }
                });

            migrationBuilder.InsertData(
                table: "PlayerMatchStat",
                columns: new[] { "Id", "MatchId", "PlayerId", "MinutesPlayed", "Goals", "Assists", "YellowCards", "RedCards", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, 90, 0, 0, 0, 0, 7.0m },
                    { 2, 1, 2, 90, 0, 1, 1, 0, 6.5m },
                    { 3, 1, 3, 65, 0, 0, 0, 0, 6.0m },
                    { 4, 1, 4, 90, 1, 2, 0, 0, 8.0m },
                    { 5, 1, 5, 80, 2, 0, 0, 0, 8.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TeamId",
                table: "Training",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId",
                table: "Match",
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

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStat_MatchId_PlayerId",
                table: "PlayerMatchStat",
                columns: new[] { "MatchId", "PlayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStat_PlayerId",
                table: "PlayerMatchStat",
                column: "PlayerId");
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
                name: "Training");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
