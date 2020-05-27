using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class correctedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 4,
                column: "TextureName",
                value: "Solid Handle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 4,
                column: "TextureName",
                value: "Solid Pointer");
        }
    }
}
