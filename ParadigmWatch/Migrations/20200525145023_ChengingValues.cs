using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class ChengingValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StandardShader",
                columns: new[] { "Id", "EnvMapIntensity", "Metalness", "NormalMapIntensity", "NormalMapPath", "Roughness" },
                values: new object[] { 6, 3, 1.0, 0.050000000000000003, "models/strap.png", 0.14999999999999999 });

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 9,
                column: "ShaderId",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "ModelPath", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[] { 9, "models/Parts/Rings/DefaultRing.gltf", "Example Ring", null, 2, 1, 2, 8, 0, null });
        }
    }
}
