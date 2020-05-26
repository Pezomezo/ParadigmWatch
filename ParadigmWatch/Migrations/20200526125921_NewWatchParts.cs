using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class NewWatchParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImagePath", "TextureName" },
                values: new object[] { "models/Silver.png", "Silver" });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "Image/gold.png");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImagePath", "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[] { "Image/Bronze.png", "If you are into that Pimpin' lifestyle", "Bronze", 250.22 });

            migrationBuilder.InsertData(
                table: "Texture",
                columns: new[] { "Id", "ImagePath", "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[,]
                {
                    { 12, "Image/JunoPattern.png", "If you are into that Pimpin' lifestyle", "Juno Dial", 250.22 },
                    { 8, "Image/BlueStrap.png", "If you are into that Pimpin' lifestyle", "Blue Leather", 250.22 },
                    { 10, "Image/Brownstrap.png", "If you are into that Pimpin' lifestyle", "Brown Leather", 250.22 },
                    { 9, "Image/RedsStrap.png", "If you are into that Pimpin' lifestyle", "Red Leather", 250.22 },
                    { 11, "Image/MercuryPattern.png", "If you are into that Pimpin' lifestyle", "Mercury Dial", 250.22 }
                });

            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "ModelPath", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[,]
                {
                    { 12, "models/Parts/BackSides/DefaultBack.gltf", "Gold Back part", null, 2, 1, 6, 2, 0, null },
                    { 13, "models/Parts/BackSides/DefaultBack.gltf", "Bronze Back part", null, 2, 1, 7, 2, 0, null },
                    { 14, "models/Parts/BackSides/DefaultBack.gltf", "Silver Back part", null, 2, 1, 5, 2, 0, null },
                    { 15, "models/Parts/Bases/DefaultBase.gltf", "Silver Base", null, 2, 1, 5, 3, 0, null },
                    { 17, "models/Parts/Bases/DefaultBase.gltf", "Bronze Base", null, 2, 1, 7, 3, 0, null },
                    { 18, "models/Parts/Decorations/DefaultDecoration.gltf", "Silver Decorations", null, 2, 1, 5, 4, 0, null },
                    { 19, "models/Parts/Decorations/DefaultDecoration.gltf", "Gold Decorations", null, 2, 1, 6, 4, 0, null },
                    { 20, "models/Parts/Decorations/DefaultDecoration.gltf", "Bronze Decorations", null, 2, 1, 7, 4, 0, null },
                    { 24, "models/Parts/Rings/DefaultRing.gltf", "Silver Ring", null, 2, 1, 5, 8, 0, null },
                    { 25, "models/Parts/Rings/DefaultRing.gltf", "Gold Ring", null, 2, 1, 6, 8, 0, null },
                    { 26, "models/Parts/Rings/DefaultRing.gltf", "Bronze Ring", null, 2, 1, 7, 8, 0, null },
                    { 16, "models/Parts/Bases/DefaultBase.gltf", "Gold Base", null, 2, 1, 6, 3, 0, null }
                });

            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "ModelPath", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[,]
                {
                    { 21, "models/Parts/Sleeves/DefaultSleeve.gltf", "Blue Sleeves", null, 1, 1, 8, 6, 0, null },
                    { 22, "models/Parts/Sleeves/DefaultSleeve.gltf", "Red Sleeves", null, 1, 1, 9, 6, 0, null },
                    { 23, "models/Parts/Sleeves/DefaultSleeve.gltf", "Brown Sleeves", null, 1, 1, 10, 6, 0, null },
                    { 10, "models/Parts/Backgrounds/Apollo.gltf", "Juno", null, 3, 1, 11, 1, 0, null },
                    { 11, "models/Parts/Backgrounds/Apollo.gltf", "Mercury", null, 3, 1, 12, 1, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImagePath", "TextureName" },
                values: new object[] { "Image/something", "Metalic" });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "Image/something");

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImagePath", "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[] { "", "", "", 0.0 });

            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "ModelPath", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[] { 9, "models/Parts/Rings/DefaultRing.gltf", "Example Ring", null, 6, 1, 2, 8, 0, null });
        }
    }
}
