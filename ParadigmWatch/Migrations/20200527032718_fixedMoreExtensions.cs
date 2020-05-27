using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class fixedMoreExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailPath",
                value: "models/Thumbnails/chromeThumbnail.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailPath",
                value: "models/Thumbnails/chromeThumbnail.png");
        }
    }
}
