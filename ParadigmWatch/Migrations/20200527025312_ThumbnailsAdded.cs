using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class ThumbnailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Texture",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 3,
                column: "NormalMapPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 11,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 12,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 13,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Texture");

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 3,
                column: "NormalMapPath",
                value: "");
        }
    }
}
