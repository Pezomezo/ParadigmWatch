using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class indexed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Apollo Pattern");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Black Sleeves");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Crystal Glass");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Juno Pattern");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Mercury Pattern");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Apollo");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Sleeves");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Glass");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Juno");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Mercury");
        }
    }
}
