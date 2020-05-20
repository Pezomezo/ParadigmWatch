using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmWatch.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true),
                    CreditCard = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundPictureFilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgrounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardShader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metalness = table.Column<double>(type: "float", nullable: false),
                    Roughness = table.Column<double>(type: "float", nullable: false),
                    NormalMapPath = table.Column<string>(nullable: true),
                    NormalMapIntensity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardShader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Texture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: false),
                    TextureName = table.Column<string>(maxLength: 50, nullable: false),
                    TextureDesc = table.Column<string>(maxLength: 150, nullable: false),
                    TexturePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WatchImagePath = table.Column<string>(nullable: true),
                    ModelPath = table.Column<string>(nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchPartType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchPartType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DiscountAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WatchPart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TextureMapId = table.Column<int>(nullable: false),
                    ShaderId = table.Column<int>(nullable: false),
                    TextMapId = table.Column<int>(nullable: false),
                    WatchComponentsId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    PartTypeId = table.Column<int>(nullable: true),
                    WatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchPart_WatchPartType_PartTypeId",
                        column: x => x.PartTypeId,
                        principalTable: "WatchPartType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WatchPart_StandardShader_ShaderId",
                        column: x => x.ShaderId,
                        principalTable: "StandardShader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchPart_TextMap_TextMapId",
                        column: x => x.TextMapId,
                        principalTable: "TextMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchPart_Texture_TextureMapId",
                        column: x => x.TextureMapId,
                        principalTable: "Texture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchPart_Watch_WatchId",
                        column: x => x.WatchId,
                        principalTable: "Watch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchID = table.Column<int>(nullable: false),
                    Quanity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Watch_WatchID",
                        column: x => x.WatchID,
                        principalTable: "Watch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelationTableWatch",
                columns: table => new
                {
                    WatchId = table.Column<int>(nullable: false),
                    WatchPartId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    watchComponentPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTableWatch", x => new { x.WatchId, x.WatchPartId });
                    table.ForeignKey(
                        name: "FK_RelationTableWatch_Watch_WatchId",
                        column: x => x.WatchId,
                        principalTable: "Watch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationTableWatch_WatchPart_WatchPartId",
                        column: x => x.WatchPartId,
                        principalTable: "WatchPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StandardShader",
                columns: new[] { "Id", "Metalness", "NormalMapIntensity", "NormalMapPath", "Roughness" },
                values: new object[,]
                {
                    { 1, 0.0, 0.10000000000000001, "models/strap.png", 0.29999999999999999 },
                    { 2, 1.0, 0.10000000000000001, "models/chrome.png", 0.14999999999999999 },
                    { 3, 0.0, 0.0, "", 0.5 },
                    { 4, 1.0, 0.0, "", 0.0 },
                    { 5, 0.0, 0.0, "", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "TextMap",
                columns: new[] { "Id", "ImagePath" },
                values: new object[] { 1, "Image/something" });

            migrationBuilder.InsertData(
                table: "Texture",
                columns: new[] { "Id", "ImagePath", "TextureDesc", "TextureName", "TexturePrice" },
                values: new object[,]
                {
                    { 7, "", "", "", 0.0 },
                    { 5, "Image/something", "Smooth life", "Metalic", 50.219999999999999 },
                    { 4, "", "You are just cruel at this point :D", "Solid Handle", 120.22 },
                    { 6, "Image/something", "If you are into that Pimpin' lifestyle", "Gold", 250.22 },
                    { 2, "models/chrome.png", "Feel the Gekko", "Chrome", 15.220000000000001 },
                    { 1, "models/strap.png", "This Leather makes you look rich&stuff", "Leather", 12.220000000000001 },
                    { 3, "models/watchFrontTexture.png", "Wanna be the most badass person? try this then!", "Apollo Dial", 33.399999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Watch",
                columns: new[] { "Id", "Description", "ModelPath", "Name", "Price", "WatchImagePath" },
                values: new object[,]
                {
                    { 1, "This is a basic model you can configure it to your liking", "models/Watch.gltf", "Apollo", 100.5, "Apollo.png" },
                    { 2, "Exciting Views, Fresh look, and has a deeper meaning by visualizing the flow of time.", "models/Watch.gltf", "Juno", 100.5, "Juno.png" },
                    { 3, "A bald statemnt. That is how I would describe this watch.", "models/Watch.gltf", "Mercury", 100.5, "Mercury.png" }
                });

            migrationBuilder.InsertData(
                table: "WatchPartType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Glass" },
                    { 1, "Pattern" },
                    { 2, "BackSide" },
                    { 3, "Base" },
                    { 4, "Decoration" },
                    { 5, "Pointer" },
                    { 6, "Sleeve" },
                    { 8, "Ring" }
                });

            migrationBuilder.InsertData(
                table: "WatchPart",
                columns: new[] { "Id", "Name", "PartTypeId", "ShaderId", "TextMapId", "TextureMapId", "TypeId", "WatchComponentsId", "WatchId" },
                values: new object[,]
                {
                    { 6, "Sleeves", null, 1, 1, 1, 6, 0, null },
                    { 2, "Chrome Back part", null, 2, 1, 2, 2, 0, null },
                    { 3, "Chrome Base", null, 2, 1, 2, 3, 0, null },
                    { 4, "Chrome Decorations", null, 2, 1, 2, 4, 0, null },
                    { 8, "Chrome Ring", null, 2, 1, 2, 8, 0, null },
                    { 1, "Apollo", null, 3, 1, 3, 1, 0, null },
                    { 5, "Silver Pointer", null, 4, 1, 4, 5, 0, null },
                    { 7, "Glass", null, 5, 1, 7, 7, 0, null }
                });

            migrationBuilder.InsertData(
                table: "RelationTableWatch",
                columns: new[] { "WatchId", "WatchPartId", "Id", "watchComponentPath" },
                values: new object[,]
                {
                    { 1, 6, 0, null },
                    { 1, 7, 0, null },
                    { 3, 5, 0, null },
                    { 2, 5, 0, null },
                    { 1, 5, 0, null },
                    { 3, 1, 0, null },
                    { 2, 1, 0, null },
                    { 1, 1, 0, null },
                    { 3, 8, 0, null },
                    { 2, 8, 0, null },
                    { 1, 8, 0, null },
                    { 3, 4, 0, null },
                    { 2, 4, 0, null },
                    { 1, 4, 0, null },
                    { 3, 3, 0, null },
                    { 2, 3, 0, null },
                    { 1, 3, 0, null },
                    { 3, 2, 0, null },
                    { 2, 2, 0, null },
                    { 1, 2, 0, null },
                    { 3, 6, 0, null },
                    { 2, 6, 0, null },
                    { 2, 7, 0, null },
                    { 3, 7, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_UserId",
                table: "Discounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserId",
                table: "Invoice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_InvoiceId",
                table: "OrderItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_WatchID",
                table: "OrderItem",
                column: "WatchID");

            migrationBuilder.CreateIndex(
                name: "IX_RelationTableWatch_WatchPartId",
                table: "RelationTableWatch",
                column: "WatchPartId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchPart_PartTypeId",
                table: "WatchPart",
                column: "PartTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchPart_ShaderId",
                table: "WatchPart",
                column: "ShaderId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchPart_TextMapId",
                table: "WatchPart",
                column: "TextMapId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchPart_TextureMapId",
                table: "WatchPart",
                column: "TextureMapId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchPart_WatchId",
                table: "WatchPart",
                column: "WatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Backgrounds");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "RelationTableWatch");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "WatchPart");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WatchPartType");

            migrationBuilder.DropTable(
                name: "StandardShader");

            migrationBuilder.DropTable(
                name: "TextMap");

            migrationBuilder.DropTable(
                name: "Texture");

            migrationBuilder.DropTable(
                name: "Watch");
        }
    }
}
