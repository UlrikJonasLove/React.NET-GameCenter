using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCenter.DataAccess.Migrations
{
    public partial class GamesAndFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GameCenters",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewlyReleased = table.Column<bool>(type: "bit", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCentersGames",
                columns: table => new
                {
                    GameCenterId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCentersGames", x => new { x.GameCenterId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameCentersGames_GameCenters_GameCenterId",
                        column: x => x.GameCenterId,
                        principalTable: "GameCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCentersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesActors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesActors", x => new { x.ActorId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GamesActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesActors_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesGenres", x => new { x.GenreId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GamesGenres_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCentersGames_GameId",
                table: "GameCentersGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesActors_GameId",
                table: "GamesActors",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenres_GameId",
                table: "GamesGenres",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCentersGames");

            migrationBuilder.DropTable(
                name: "GamesActors");

            migrationBuilder.DropTable(
                name: "GamesGenres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GameCenters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);
        }
    }
}
