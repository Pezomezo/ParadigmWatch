using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class UpdatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelPath",
                table: "Watch");

            migrationBuilder.AddColumn<string>(
                name: "ModelPath",
                table: "WatchPart",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnvMapIntensity",
                table: "StandardShader",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelPath",
                value: "models/Parts/Backgrounds/Apollo.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelPath",
                value: "models/Parts/BackSides/DefaultBack.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelPath",
                value: "models/Parts/Bases/DefaultBase.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModelPath",
                value: "models/Parts/Decorations/DefaultDecoration.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModelPath",
                value: "models/Parts/Pointers/DefaultPointer.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModelPath",
                value: "models/Parts/Sleeves/DefaultSleeve.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 7,
                column: "ModelPath",
                value: "models/Parts/Glasses/DefaultGlass.gltf");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 8,
                column: "ModelPath",
                value: "models/Parts/Rings/DefaultRing.gltf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelPath",
                table: "WatchPart");

            migrationBuilder.DropColumn(
                name: "EnvMapIntensity",
                table: "StandardShader");

            migrationBuilder.AddColumn<string>(
                name: "ModelPath",
                table: "Watch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelPath",
                value: "models/Watch.gltf");

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelPath",
                value: "models/Watch.gltf");

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelPath",
                value: "models/Watch.gltf");
        }
    }
}
