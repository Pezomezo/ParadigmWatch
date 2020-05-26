using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class fixedUpData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 1,
                column: "TexturePrice",
                value: 50.219999999999999);

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Cold but Cool", 100.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[] { "Simple but elegant", "Solid Pointer", 80.219999999999999 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "James Bond would have the same", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "TexturePrice",
                value: 300.22000000000003);

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "This still makes you look no.1", 200.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Colorful look for a colorful personality", 175.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Bursting with energy", 175.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Smooth criminal", 150.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "This will make some heads turn!", 50.219999999999999 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Represents the flow of time", 50.219999999999999 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 13,
                column: "TextureDesc",
                value: "Gorilla Glass XI");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 5,
                column: "TextureMapId",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 1,
                column: "TexturePrice",
                value: 12.220000000000001);

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Feel the Gekko", 15.220000000000001 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[] { "You are just cruel at this point :D", "Solid Handle", 120.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "Smooth life", 50.219999999999999 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 6,
                column: "TexturePrice",
                value: 250.22);

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "If you are into that Pimpin' lifestyle", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "If you are into that Pimpin' lifestyle", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "If you are into that Pimpin' lifestyle", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "If you are into that Pimpin' lifestyle", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "If you are into that Pimpin' lifestyle", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "TextureDesc", "TexturePrice" },
                values: new object[] { "If you are into that Pimpin' lifestyle", 250.22 });

            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 13,
                column: "TextureDesc",
                value: "If you are into that Pimpin' lifestyle");

            migrationBuilder.UpdateData(
                table: "WatchPart",
                keyColumn: "Id",
                keyValue: 5,
                column: "TextureMapId",
                value: 4);
        }
    }
}
