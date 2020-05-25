using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class exampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "ModelPath", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[] { 9, "models/Parts/Rings/DefaultRing.gltf", "Example Ring", null, 2, 1, 2, 8, 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
