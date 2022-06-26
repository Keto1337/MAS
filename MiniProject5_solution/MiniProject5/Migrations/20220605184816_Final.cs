using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject5.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationInMins",
                table: "FeatureFilm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FeatureFilm",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "DurationInMins",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2015, 6, 5, 20, 48, 15, 955, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2017, 6, 5, 20, 48, 15, 953, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2019, 6, 5, 20, 48, 15, 955, DateTimeKind.Local).AddTicks(5325));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMins",
                table: "FeatureFilm");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2015, 6, 5, 18, 58, 35, 957, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2017, 6, 5, 18, 58, 35, 953, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2019, 6, 5, 18, 58, 35, 957, DateTimeKind.Local).AddTicks(9081));
        }
    }
}
