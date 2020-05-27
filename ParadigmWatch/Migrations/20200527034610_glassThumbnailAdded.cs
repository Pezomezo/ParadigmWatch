using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class glassThumbnailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 13,
                column: "ThumbnailPath",
                value: "models/Thumbnails/glassThumbnail.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 13,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");
        }
    }
}
