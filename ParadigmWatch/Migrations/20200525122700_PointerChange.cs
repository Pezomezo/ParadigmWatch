using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class PointerChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 4,
                column: "Metalness",
                value: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 4,
                column: "Metalness",
                value: 1.0);
        }
    }
}
