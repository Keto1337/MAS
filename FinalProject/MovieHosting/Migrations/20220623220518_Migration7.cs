using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieHosting.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MovieCost = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.IdMovie);
                });

            migrationBuilder.CreateTable(
                name: "MovieParticipants",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PersonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieParticipants", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "FeatureFilm",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    DurationInMins = table.Column<int>(type: "int", nullable: false)
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
                name: "MovieOfWeek",
                columns: table => new
                {
                    IdMovieOfWeek = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieOfWeek", x => x.IdMovieOfWeek);
                    table.ForeignKey(
                        name: "FK_MovieOfWeek_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AdminMovie",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Admin_Movie_PK", x => new { x.IdAdmin, x.IdMovie });
                    table.ForeignKey(
                        name: "FK_AdminMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminMovie_MovieParticipants_IdAdmin",
                        column: x => x.IdAdmin,
                        principalTable: "MovieParticipants",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientMovie",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_Movie_PK", x => new { x.IdClient, x.IdMovie });
                    table.ForeignKey(
                        name: "FK_ClientMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientMovie_MovieParticipants_IdClient",
                        column: x => x.IdClient,
                        principalTable: "MovieParticipants",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Contact_MovieParticipants_IdClient",
                        column: x => x.IdClient,
                        principalTable: "MovieParticipants",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieParticipant",
                columns: table => new
                {
                    IdMovieParticipant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParticipant = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    MovieAward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoviePayment = table.Column<double>(type: "float", nullable: false),
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieParticipant", x => x.IdMovieParticipant);
                    table.ForeignKey(
                        name: "FK_MovieParticipant_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieParticipant_MovieParticipants_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "MovieParticipants",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    IdPaymentMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.IdPaymentMethod);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_MovieParticipants_IdClient",
                        column: x => x.IdClient,
                        principalTable: "MovieParticipants",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesSeason",
                columns: table => new
                {
                    IdSeriesSeason = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    IdSeries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesSeason", x => x.IdSeriesSeason);
                    table.ForeignKey(
                        name: "FK_SeriesSeason_Series_IdSeries",
                        column: x => x.IdSeries,
                        principalTable: "Series",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisode",
                columns: table => new
                {
                    IdSeriesEpisode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    IdSeason = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisode", x => x.IdSeriesEpisode);
                    table.ForeignKey(
                        name: "FK_SeriesEpisode_SeriesSeason_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "SeriesSeason",
                        principalColumn: "IdSeriesSeason",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "IdMovie", "Description", "Genres", "MovieCost", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 2, "Description2Description2 Description2 Description2Description2Description2 Description2 Description2Description2Description2 Description2Description2", "[\"Thriller\",\"Action\"]", 5.9900000000000002, "Film_Name2", new DateTime(2015, 6, 24, 0, 5, 17, 651, DateTimeKind.Local).AddTicks(9280) },
                    { 1, "A high school teacher with terminal cancer, along with his former student, manufactures and sells methamphetamine in order to secure a prosperous future for his family.", "[\"Crime TV series\",\"Drama TV series\",\"Thriller\",\"Cruel\"]", 5.9900000000000002, "Breaking Bad", new DateTime(2013, 6, 24, 0, 5, 17, 646, DateTimeKind.Local).AddTicks(5005) },
                    { 3, "The infamous gang is led by the brutal Tommy Shelby, the leader of a crime family determined to achieve new heights at any cost.", "[\"Crime TV series\",\"Historical films\"]", 6.9900000000000002, "Peaky Blinders", new DateTime(2017, 6, 24, 0, 5, 17, 652, DateTimeKind.Local).AddTicks(78) }
                });

            migrationBuilder.InsertData(
                table: "MovieParticipants",
                columns: new[] { "IdPerson", "Bio", "FirstName", "LastName", "PersonType" },
                values: new object[,]
                {
                    { 1, null, "FirstName1", "LastName1", "[0]" },
                    { 2, null, "FirstName2", "LastName2", "[0]" },
                    { 3, null, "FirstName3", "LastName3", "[1]" },
                    { 4, null, "FirstName4", "LastName4", "[1]" },
                    { 5, null, "FirstName5", "LastName5", "[2]" }
                });

            migrationBuilder.InsertData(
                table: "AdminMovie",
                columns: new[] { "IdAdmin", "IdMovie" },
                values: new object[,]
                {
                    { 5, 3 },
                    { 5, 1 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ClientMovie",
                columns: new[] { "IdClient", "IdMovie", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "IdContact", "Email", "IdClient", "Phone" },
                values: new object[,]
                {
                    { 1, "s21120@pjwstk.edu.pl", 1, "+48333333333" },
                    { 2, "s21121@pjwstk.edu.pl", 2, "+48334433333" },
                    { 3, "s21122@pjwstk.edu.pl", 3, "+48335533333" }
                });

            migrationBuilder.InsertData(
                table: "FeatureFilm",
                columns: new[] { "IdMovie", "DurationInMins" },
                values: new object[] { 2, 120 });

            migrationBuilder.InsertData(
                table: "MovieOfWeek",
                columns: new[] { "IdMovieOfWeek", "IdMovie", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 19, 0, 5, 17, 653, DateTimeKind.Local).AddTicks(4559) });

            migrationBuilder.InsertData(
                table: "MovieParticipant",
                columns: new[] { "IdMovieParticipant", "IdMovie", "IdParticipant", "MovieAward", "MoviePayment", "RoleType" },
                values: new object[,]
                {
                    { 6, 3, 4, "some", 300000.0, 1 },
                    { 1, 1, 3, "some", 500000.0, 0 },
                    { 2, 1, 4, "some", 300000.0, 0 },
                    { 3, 1, 3, "some", 300000.0, 2 },
                    { 4, 3, 4, "some", 500000.0, 0 },
                    { 5, 3, 3, "some", 300000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "IdPaymentMethod", "IdClient", "PaymentType", "ReferenceNumber" },
                values: new object[,]
                {
                    { 1, 1, 0, "32131221321312" },
                    { 2, 1, 1, "PL231123213" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                column: "IdMovie",
                values: new object[]
                {
                    1,
                    3
                });

            migrationBuilder.InsertData(
                table: "SeriesSeason",
                columns: new[] { "IdSeriesSeason", "Description", "IdSeries", "Name", "SeasonNumber" },
                values: new object[] { 1, "desc", 1, "sr1s1", 1 });

            migrationBuilder.InsertData(
                table: "SeriesSeason",
                columns: new[] { "IdSeriesSeason", "Description", "IdSeries", "Name", "SeasonNumber" },
                values: new object[] { 2, "desc", 1, "sr1s2", 2 });

            migrationBuilder.InsertData(
                table: "SeriesEpisode",
                columns: new[] { "IdSeriesEpisode", "Description", "EpisodeNumber", "IdSeason", "Name" },
                values: new object[,]
                {
                    { 1, "desc", 1, 1, "sr1s1ep1" },
                    { 2, "desc", 2, 1, "sr1s1ep2" },
                    { 5, "desc", 1, 1, "sr3s1ep1" },
                    { 6, "desc", 2, 1, "sr3s1ep2" },
                    { 3, "desc", 1, 2, "sr1s2ep1" },
                    { 4, "desc", 2, 2, "sr1s2ep2" },
                    { 7, "desc", 1, 2, "sr3s2ep1" },
                    { 8, "desc", 2, 2, "sr3s2ep2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMovie_IdMovie",
                table: "AdminMovie",
                column: "IdMovie");

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
                name: "IX_MovieOfWeek_IdMovie",
                table: "MovieOfWeek",
                column: "IdMovie",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieParticipant_IdMovie",
                table: "MovieParticipant",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_MovieParticipant_IdParticipant",
                table: "MovieParticipant",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_IdClient",
                table: "PaymentMethod",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesEpisode_IdSeason",
                table: "SeriesEpisode",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesSeason_IdSeries",
                table: "SeriesSeason",
                column: "IdSeries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMovie");

            migrationBuilder.DropTable(
                name: "ClientMovie");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "FeatureFilm");

            migrationBuilder.DropTable(
                name: "MovieOfWeek");

            migrationBuilder.DropTable(
                name: "MovieParticipant");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "SeriesEpisode");

            migrationBuilder.DropTable(
                name: "MovieParticipants");

            migrationBuilder.DropTable(
                name: "SeriesSeason");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
