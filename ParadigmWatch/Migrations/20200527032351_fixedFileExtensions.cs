using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class fixedFileExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailPath",
                value: "models/Thumbnails/blackThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThumbnailPath",
                value: "models/Thumbnails/chromeThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThumbnailPath",
                value: "models/Thumbnails/silverThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThumbnailPath",
                value: "models/Thumbnails/goldThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThumbnailPath",
                value: "models/Thumbnails/bronzThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                column: "ThumbnailPath",
                value: "models/Thumbnails/blueThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                column: "ThumbnailPath",
                value: "models/Thumbnails/redThumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                column: "ThumbnailPath",
                value: "models/Thumbnails/brownThumbnail.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailPath",
                value: "models/Thumbnails/blackThumbnail.png");

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
                value: "models/Thumbnails/chromeThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThumbnailPath",
                value: "models/Thumbnails/silverThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThumbnailPath",
                value: "models/Thumbnails/goldThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThumbnailPath",
                value: "models/Thumbnails/bronzThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                column: "ThumbnailPath",
                value: "models/Thumbnails/blueThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                column: "ThumbnailPath",
                value: "models/Thumbnails/redThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                column: "ThumbnailPath",
                value: "models/Thumbnails/brownThumbnail.png");
        }
    }
}
