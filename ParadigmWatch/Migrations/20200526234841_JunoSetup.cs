using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class JunoSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[,]
                {
                    { 3, 10, 0, null },
                    { 3, 14, 0, null },
                    { 3, 15, 0, null },
                    { 3, 18, 0, null },
                    { 3, 23, 0, null },
                    { 3, 24, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 18 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[,]
                {
                    { 3, 1, 0, null },
                    { 3, 2, 0, null },
                    { 3, 3, 0, null },
                    { 3, 4, 0, null },
                    { 3, 6, 0, null },
                    { 3, 8, 0, null }
                });
        }
    }
}
