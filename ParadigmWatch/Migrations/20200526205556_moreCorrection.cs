using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class moreCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 5,
                column: "TextureMapId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 5,
                column: "TextureMapId",
                value: 5);
        }
    }
}
