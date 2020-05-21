using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class NewBacgroundsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Backgrounds",
                columns: new[] { "Id", "BackgroundName", "fileName" },
                values: new object[,]
                {
                    { 7, "ShanghaiBG", "nx.png" },
                    { 8, "ShanghaiBG", "ny.png" },
                    { 9, "ShanghaiBG", "nz.png" },
                    { 10, "ShanghaiBG", "px.png" },
                    { 11, "ShanghaiBG", "py.png" },
                    { 12, "ShanghaiBG", "pz.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
