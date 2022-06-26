using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject5.Migrations
{
    public partial class AddedComposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_IdClient",
                table: "Contact");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "IdContact",
                keyValue: 2,
                column: "Phone",
                value: "+48334433333");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "IdContact",
                keyValue: 3,
                column: "Phone",
                value: "+48335533333");

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

            migrationBuilder.CreateIndex(
                name: "IX_Contact_IdClient",
                table: "Contact",
                column: "IdClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_IdClient",
                table: "Contact");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "IdContact",
                keyValue: 2,
                column: "Phone",
                value: "+48333333333");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "IdContact",
                keyValue: 3,
                column: "Phone",
                value: "+48333333333");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2015, 6, 2, 17, 8, 56, 438, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2017, 6, 2, 17, 8, 56, 436, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2019, 6, 2, 17, 8, 56, 438, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.CreateIndex(
                name: "IX_Contact_IdClient",
                table: "Contact",
                column: "IdClient",
                unique: true);
        }
    }
}
