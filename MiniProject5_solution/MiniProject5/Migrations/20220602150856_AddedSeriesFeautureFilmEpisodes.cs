using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject5.Migrations
{
    public partial class AddedSeriesFeautureFilmEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ClientType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MovieCost = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.IdMovie);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.IdContact);
                    table.ForeignKey(
                        name: "FK_Contact_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientMovie",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_Movie_PK", x => new { x.IdClient, x.IdMovie });
                    table.ForeignKey(
                        name: "FK_ClientMovie_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureFilm",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFilm", x => x.IdMovie);
                    table.ForeignKey(
                        name: "FK_FeatureFilm_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.IdMovie);
                    table.ForeignKey(
                        name: "FK_Series_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisode",
                columns: table => new
                {
                    IdSeriesEpisode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdSeries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisode", x => x.IdSeriesEpisode);
                    table.ForeignKey(
                        name: "FK_SeriesEpisode_Series_IdSeries",
                        column: x => x.IdSeries,
                        principalTable: "Series",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Bio", "ClientType", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, 0, "FirstName1", "LastName1" },
                    { 2, null, 0, "FirstName2", "LastName2" },
                    { 3, null, 0, "FirstName3", "LastName3" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "IdMovie", "Description", "MovieCost", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 3, "Description3", 60.0, "Film3", new DateTime(2015, 6, 2, 17, 8, 56, 438, DateTimeKind.Local).AddTicks(2767) },
                    { 1, "Description1", 50.0, "Series1", new DateTime(2017, 6, 2, 17, 8, 56, 436, DateTimeKind.Local).AddTicks(676) },
                    { 2, "Description2", 50.0, "Series2", new DateTime(2019, 6, 2, 17, 8, 56, 438, DateTimeKind.Local).AddTicks(2417) }
                });

            migrationBuilder.InsertData(
                table: "ClientMovie",
                columns: new[] { "IdClient", "IdMovie" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "IdContact", "Email", "IdClient", "Phone" },
                values: new object[,]
                {
                    { 1, "s21120@pjwstk.edu.pl", 1, "+48333333333" },
                    { 2, "s21121@pjwstk.edu.pl", 2, "+48333333333" },
                    { 3, "s21122@pjwstk.edu.pl", 3, "+48333333333" }
                });

            migrationBuilder.InsertData(
                table: "FeatureFilm",
                column: "IdMovie",
                value: 3);

            migrationBuilder.InsertData(
                table: "Series",
                column: "IdMovie",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "SeriesEpisode",
                columns: new[] { "IdSeriesEpisode", "Description", "IdSeries", "Name" },
                values: new object[,]
                {
                    { 1, "desc", 1, "sr1ep1" },
                    { 2, "desc", 1, "sr1ep2" },
                    { 3, "desc", 2, "sr2ep1" },
                    { 4, "desc", 2, "sr2ep2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientMovie_IdMovie",
                table: "ClientMovie",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_IdClient",
                table: "Contact",
                column: "IdClient",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesEpisode_IdSeries",
                table: "SeriesEpisode",
                column: "IdSeries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientMovie");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "FeatureFilm");

            migrationBuilder.DropTable(
                name: "SeriesEpisode");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
