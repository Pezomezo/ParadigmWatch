using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class datacorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Texture",
                columns: new[] { "Id", "ImagePath", "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[] { 13, "", "If you are into that Pimpin' lifestyle", "Glass", 0.0 });

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 10,
                column: "TextureMapId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 11,
                column: "TextureMapId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 7,
                column: "TextureMapId",
                value: 13);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100.5);

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 100.5);

            migrationBuilder.UpdateData(
                table: "Watch",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 100.5);

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 10,
                column: "TextureMapId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 11,
                column: "TextureMapId",
                value: 12);

            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "ModelPath", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[] { 7, "models/Parts/Glasses/DefaultGlass.gltf", "Crystal Glass", null, 5, 1, 7, 7, 0, null });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[] { 3, 7, 0, null });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[] { 2, 7, 0, null });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[] { 1, 7, 0, null });
        }
    }
}
