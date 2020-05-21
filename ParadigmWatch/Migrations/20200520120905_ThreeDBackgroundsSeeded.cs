using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class ThreeDBackgroundsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundPictureFilePath",
                table: "Backgrounds");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundName",
                table: "Backgrounds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fileName",
                table: "Backgrounds",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Backgrounds",
                columns: new[] { "Id", "BackgroundName", "fileName" },
                values: new object[,]
                {
                    { 1, "HallwayBG", "nx.png" },
                    { 2, "HallwayBG", "ny.png" },
                    { 3, "HallwayBG", "nz.png" },
                    { 4, "HallwayBG", "px.png" },
                    { 5, "HallwayBG", "py.png" },
                    { 6, "HallwayBG", "pz.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "BackgroundName",
                table: "Backgrounds");

            migrationBuilder.DropColumn(
                name: "fileName",
                table: "Backgrounds");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundPictureFilePath",
                table: "Backgrounds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
