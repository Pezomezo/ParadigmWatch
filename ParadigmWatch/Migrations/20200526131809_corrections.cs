using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class corrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "models/gold.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: "models/Bronze.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: "models/BlueStrap.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: "models/RedsStrap.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: "models/Brownstrap.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "models/MercuryPattern.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "models/JunoPattern.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "Image/gold.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: "Image/Bronze.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: "Image/BlueStrap.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: "Image/RedsStrap.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: "Image/Brownstrap.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "Image/MercuryPattern.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "Image/JunoPattern.png");
        }
    }
}
