using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class Metal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalMapIntensity",
                value: 0.050000000000000003);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalMapIntensity",
                value: 0.10000000000000001);
        }
    }
}
