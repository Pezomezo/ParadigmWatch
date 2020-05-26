using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class envMapInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnvMapIntensity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnvMapIntensity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 3,
                column: "EnvMapIntensity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 4,
                column: "EnvMapIntensity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 5,
                column: "EnvMapIntensity",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnvMapIntensity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnvMapIntensity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 3,
                column: "EnvMapIntensity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 4,
                column: "EnvMapIntensity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 5,
                column: "EnvMapIntensity",
                value: 0);
        }
    }
}
