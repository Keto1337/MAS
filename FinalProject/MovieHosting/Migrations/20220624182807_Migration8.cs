using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieHosting.Migrations
{
    public partial class Migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2015, 6, 24, 20, 28, 6, 475, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2013, 6, 24, 20, 28, 6, 473, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2017, 6, 24, 20, 28, 6, 475, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "MovieOfWeek",
                keyColumn: "IdMovieOfWeek",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2022, 6, 19, 20, 28, 6, 476, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "MovieParticipants",
                keyColumn: "IdPerson",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Illia", "Zviezdin" });

            migrationBuilder.UpdateData(
                table: "MovieParticipants",
                keyColumn: "IdPerson",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Emil", "Wcislo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2015, 6, 24, 0, 5, 17, 651, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2013, 6, 24, 0, 5, 17, 646, DateTimeKind.Local).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2017, 6, 24, 0, 5, 17, 652, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "MovieOfWeek",
                keyColumn: "IdMovieOfWeek",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2022, 6, 19, 0, 5, 17, 653, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "MovieParticipants",
                keyColumn: "IdPerson",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "FirstName3", "LastName3" });

            migrationBuilder.UpdateData(
                table: "MovieParticipants",
                keyColumn: "IdPerson",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "FirstName4", "LastName4" });
        }
    }
}
