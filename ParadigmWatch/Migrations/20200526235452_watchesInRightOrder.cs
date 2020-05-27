using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class watchesInRightOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 8 });

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
                keyValues: new object[] { 3, 24 });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[,]
                {
                    { 2, 10, 0, null },
                    { 2, 14, 0, null },
                    { 2, 15, 0, null },
                    { 2, 18, 0, null },
                    { 2, 23, 0, null },
                    { 2, 24, 0, null },
                    { 3, 11, 0, null },
                    { 3, 13, 0, null },
                    { 3, 17, 0, null },
                    { 3, 20, 0, null },
                    { 3, 26, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 20 });

            migrationBuilder.DeleteData(
                table: "RelationTableWatch",
                keyColumns: new[] { "WatchId", "WatchPartId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[,]
                {
                    { 2, 1, 0, null },
                    { 2, 2, 0, null },
                    { 2, 3, 0, null },
                    { 2, 4, 0, null },
                    { 2, 6, 0, null },
                    { 2, 8, 0, null },
                    { 3, 10, 0, null },
                    { 3, 14, 0, null },
                    { 3, 15, 0, null },
                    { 3, 18, 0, null },
                    { 3, 24, 0, null }
                });
        }
    }
}
