using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsMenuItem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0517f36e-53b1-4a0d-b6b3-599afdd926cf", null, "Yönetici rolü", "Admin", "ADMIN" },
                    { "c44cd475-5365-409f-845c-6ea238190b2b", null, "Normal kullanıcı rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", 0, "Kadıköy", "İstanbul", "a2f29f94-e6ae-4ca1-b3b3-bfeca1516ddc", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testuser@gmail.com", true, "Esin", 2, "Çelik", false, null, "TESTUSER@GMAIL.COM", "TESTUSER", "AQAAAAIAAYagAAAAEOLVJ7fuGxu9mLtC0mr/zp3ad8SYIUSa3qQKVEEtITynGbm/BOh8Csbd433FGo/80Q==", null, false, "5ab818a9-bf3c-4f8b-a6ac-5cbefd4eb902", false, "testuser" },
                    { "d4757375-a497-496b-85dc-a510027bd9b1", 0, "Ataşehir", "İstanbul", "57dd9fa4-156b-4ae0-b262-674abee11340", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testadmin@gmail.com", true, "Ali", 3, "Cabbar", false, null, "TESTADMIN@GMAIL.COM", "TESTADMIN", "AQAAAAIAAYagAAAAEM8ySgH7yQJMR6+2pJHo4y5aHDdmDV3l9r4HpRRgyUIqaT7QfPlkMs6V3MCuWBvNLQ==", null, false, "1fe9deaa-a0fa-4a75-9d97-90b62661e7d5", false, "testadmin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsMenuItem", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 0, 0, 0, 0)), "Bilgisayarlar, akıllı telefonlar, tabletler, televizyonlar ve diğer tüm elektronik cihazlar bu kategoride bulunabilir. Teknoloji tutkunları için en yeni ve popüler ürünler burada!", "/images/categories/elektronik.png", true, false, true, "Elektronik", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), "Kadın, erkek ve çocuk giyim ürünleri, ayakkabılar, çantalar ve aksesuarlar bu kategoride. Trendleri yakalayın ve tarzınızı yansıtın!", "/images/categories/moda.png", true, false, true, "Moda", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), "Ev dekorasyonu, mobilyalar, mutfak gereçleri, bahçe ürünleri ve daha fazlası bu kategoride. Evinizi güzelleştirmek için ihtiyacınız olan her şey burada!", "/images/categories/ev-yasam.png", true, false, true, "Ev & Yaşam", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), "Spor ekipmanları, outdoor giyim, kamp malzemeleri, bisikletler ve fitness ürünleri bu kategoride. Aktif bir yaşam için ihtiyacınız olan her şey burada!", "/images/categories/spor-outdoor.png", true, false, true, "Spor & Outdoor", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), "Romanlar, kişisel gelişim kitapları, akademik yayınlar, dergiler ve daha fazlası bu kategoride. Okuma tutkunları için geniş bir seçki!", "/images/categories/kitap-dergi.png", true, false, true, "Kitap & Dergi", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), "Çocuk oyuncakları, yapbozlar, model kitler, hobi malzemeleri ve koleksiyon ürünleri bu kategoride. Hem çocuklar hem de yetişkinler için eğlenceli seçenekler!", "/images/categories/oyuncak-hobi.png", true, false, false, "Oyuncak & Hobi", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), "Cilt bakım ürünleri, makyaj malzemeleri, parfümler, saç bakım ürünleri ve daha fazlası bu kategoride. Kendinizi şımartın ve bakım rutininizi oluşturun!", "/images/categories/kozmetik-bakim.png", true, false, false, "Kozmetik & Kişisel Bakım", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), "Valizler, sırt çantaları, seyahat aksesuarları ve seyahat planlaması için gerekli ürünler bu kategoride. Yeni yerler keşfetmeye hazır olun!", "/images/categories/seyahat-valiz.png", false, false, false, "Seyahat & Valiz", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), "Bebek giysileri, bebek bakım ürünleri, oyuncaklar, çocuk odası dekorasyonu ve daha fazlası bu kategoride. Bebekler ve çocuklar için en kaliteli ürünler!", "/images/categories/bebek-cocuk.png", true, false, false, "Bebek & Çocuk", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), "Araç bakım ürünleri, yedek parçalar, araç içi aksesuarlar ve otomotiv ekipmanları bu kategoride. Araç tutkunları için ihtiyaç duyulan her şey!", "/images/categories/otomotiv.png", false, false, false, "Otomotiv", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "Name", "Price", "Properties", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9590), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9590), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/laptop.png", true, false, false, "Dizüstü Bilgisayar", 1500.00m, "16GB RAM, 512GB SSD, Intel i7 İşlemci", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9590), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/smartphone.png", true, false, false, "Akıllı Telefon", 800.00m, "128GB Depolama, 6GB RAM, 5G Desteği", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/tablet.png", true, false, false, "Tablet", 600.00m, "10.5 inç Ekran, 256GB Depolama, Kalem Desteği", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/smartwatch.png", true, false, false, "Akıllı Saat", 250.00m, "GPS, Kalp Atışı Ölçer, Suya Dayanıklı", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/earbuds.png", false, false, false, "Kablosuz Kulaklık", 150.00m, "Gürültü Önleyici, 20 Saat Pil Ömrü", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/men-jacket.png", true, false, false, "Erkek Ceket", 120.00m, "Slim Fit, Kumaş Ceket", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/women-dress.png", true, false, false, "Kadın Elbise", 80.00m, "Yazlık Desenli, Pamuklu", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sneakers.png", true, false, false, "Spor Ayakkabı", 90.00m, "Hafif, Nefes Alabilir Taban", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/bag.png", true, false, false, "Çanta", 70.00m, "Deri, Günlük Kullanım", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sunglasses.png", false, false, false, "Güneş Gözlüğü", 50.00m, "UV Koruma, Polarize Cam", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/dinner-set.png", true, false, false, "Yemek Takımı", 100.00m, "12 Parça, Porselen", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sofa.png", true, false, false, "Kanepe", 500.00m, "3 Kişilik, Kumaş Kaplama", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/bed-sheet.png", true, false, false, "Yatak Örtüsü", 60.00m, "Pamuklu, 200x220 cm", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9650), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/lamp.png", true, false, false, "Masa Lambası", 40.00m, "LED, Ayarlanabilir Işık", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/vacuum.png", false, false, false, "Süpürge", 120.00m, "Elektrikli, HEPA Filtre", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/gym-bag.png", true, false, false, "Spor Çantası", 45.00m, "30 Litre, Çok Bölmeli", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/tent.png", true, false, false, "Tent", 200.00m, "4 Kişilik, Su Geçirmez", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/bike.png", true, false, false, "Bisiklet", 350.00m, "21 Vites, Dağ Bisikleti", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/treadmill.png", true, false, false, "Koşu Bandı", 600.00m, "Katlanabilir, 12 Program", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/gloves.png", false, false, false, "Spor Eldiveni", 25.00m, "Antrenman için, Ergonomik", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 21, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/novel.png", true, false, false, "Roman Kitabı", 20.00m, "En Çok Satanlar Listesinden", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 22, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/self-help.png", true, false, false, "Kişisel Gelişim Kitabı", 25.00m, "Motivasyon ve Başarı İçin", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 23, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sci-fi.png", true, false, false, "Bilim Kurgu Kitabı", 30.00m, "Klasik Bilim Kurgu Eseri", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9670), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 24, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/magazine.png", true, false, false, "Dergi", 10.00m, "Aylık Teknoloji Dergisi", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 25, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/kids-book.png", false, false, false, "Çocuk Kitabı", 15.00m, "Resimli, Eğitici Hikayeler", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 26, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/lego.png", true, false, false, "Lego Seti", 80.00m, "1000 Parça, Yaratıcı Set", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 27, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/model-plane.png", true, false, false, "Model Uçak", 50.00m, "1:100 Ölçekli, Detaylı", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 28, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/puzzle.png", true, false, false, "Puzzle", 30.00m, "1000 Parça, Manzara Temalı", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 29, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/coloring-book.png", true, false, false, "Boyama Kitabı", 20.00m, "Yetişkinler İçin Mandala", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 30, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/rc-car.png", true, false, false, "RC Araba", 70.00m, "Uzaktan Kumandalı, Hızlı", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 31, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/moisturizer.png", true, false, false, "Nemlendirici Krem", 40.00m, "Cilt Bariyerini Güçlendirir", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 32, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/lipstick.png", true, false, false, "Ruj", 25.00m, "Uzun Süre Kalıcı, 12 Renk Seçeneği", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 33, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/perfume.png", true, false, false, "Parfüm", 60.00m, "100 ml, Günlük Kullanım", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 34, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/shampoo.png", true, false, false, "Şampuan", 15.00m, "Saç Dökülmesine Karşı Etkili", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 35, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/razor.png", true, false, false, "Tıraş Makinesi", 90.00m, "Islak & Kuru Kullanım", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 36, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/diapers.png", true, false, false, "Bebek Bezi", 40.00m, "Hipoalerjenik, 120 Adet", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 37, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/stroller.png", true, false, false, "Bebek Arabası", 200.00m, "Katlanabilir, Hafif", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 38, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/doll.png", true, false, false, "Oyuncak Bebek", 35.00m, "Gerçekçi Tasarım, 30 cm", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 39, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/kids-bike.png", true, false, false, "Çocuk Bisikleti", 100.00m, "12 inç, Yardımcı Tekerlekli", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 40, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/baby-clothes.png", true, false, false, "Bebek Giysisi", 20.00m, "Pamuklu, Rahat", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 713, DateTimeKind.Unspecified).AddTicks(9700), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c44cd475-5365-409f-845c-6ea238190b2b", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e" },
                    { "0517f36e-53b1-4a0d-b6b3-599afdd926cf", "d4757375-a497-496b-85dc-a510027bd9b1" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "d4757375-a497-496b-85dc-a510027bd9b1", new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "ApplicationUserId", "City", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "OrderStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Address 1", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 2", new DateTimeOffset(new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "Address 2", "d4757375-a497-496b-85dc-a510027bd9b1", "City 3", new DateTimeOffset(new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, "Address 3", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 4", new DateTimeOffset(new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, "Address 4", "d4757375-a497-496b-85dc-a510027bd9b1", "City 5", new DateTimeOffset(new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, "Address 5", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 1", new DateTimeOffset(new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, "Address 6", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 2", new DateTimeOffset(new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, "Address 7", "d4757375-a497-496b-85dc-a510027bd9b1", "City 3", new DateTimeOffset(new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, "Address 8", "d4757375-a497-496b-85dc-a510027bd9b1", "City 4", new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, "Address 9", "d4757375-a497-496b-85dc-a510027bd9b1", "City 5", new DateTimeOffset(new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, "Address 10", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 1", new DateTimeOffset(new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, "Address 11", "d4757375-a497-496b-85dc-a510027bd9b1", "City 2", new DateTimeOffset(new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, "Address 12", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 3", new DateTimeOffset(new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, "Address 13", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 4", new DateTimeOffset(new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, "Address 14", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 5", new DateTimeOffset(new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, "Address 15", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 1", new DateTimeOffset(new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, "Address 16", "d4757375-a497-496b-85dc-a510027bd9b1", "City 2", new DateTimeOffset(new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, "Address 17", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 3", new DateTimeOffset(new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, "Address 18", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 4", new DateTimeOffset(new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, "Address 19", "d4757375-a497-496b-85dc-a510027bd9b1", "City 5", new DateTimeOffset(new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, "Address 20", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 1", new DateTimeOffset(new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 4, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 2, 16 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 25 },
                    { 9, 25 },
                    { 6, 26 },
                    { 9, 26 },
                    { 6, 27 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 9, 30 },
                    { 7, 31 },
                    { 7, 32 },
                    { 7, 33 },
                    { 7, 34 },
                    { 7, 35 },
                    { 9, 36 },
                    { 9, 37 },
                    { 6, 38 },
                    { 9, 38 },
                    { 4, 39 },
                    { 9, 39 },
                    { 2, 40 },
                    { 9, 40 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, 11, 1, 387m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 3, 4, 458m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 28, 2, 163m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 30, 2, 16m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 14, 2, 92m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 37, 2, 221m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, 27, 1, 222m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, 11, 2, 11m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, 37, 3, 365m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, 40, 1, 127m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 4, 28, 1, 43m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4440), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 4, 17, 4, 330m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4440), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 5, 39, 2, 273m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 6, 12, 4, 456m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 6, 23, 4, 175m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 6, 28, 1, 351m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 7, 17, 1, 96m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 7, 26, 4, 227m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 15, 1, 481m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 20, 4, 367m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 21, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 20, 1, 187m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 22, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 9, 30, 5, 302m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 23, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 10, 25, 4, 81m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 24, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 10, 1, 1, 243m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 25, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4520), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 10, 30, 1, 420m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 26, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 11, 7, 1, 354m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 27, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 11, 4, 2, 110m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 28, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 12, 35, 1, 385m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 29, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 12, 8, 5, 496m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 30, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 12, 40, 2, 17m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 31, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 12, 14, 1, 122m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 32, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 16, 5, 95m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 33, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 9, 4, 15m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 34, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 21, 1, 114m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 35, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 30, 5, 301m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 36, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 14, 21, 4, 268m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 37, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 14, 20, 5, 122m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 38, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 14, 38, 4, 67m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 39, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 15, 31, 1, 141m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 40, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 15, 3, 2, 481m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 41, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 16, 16, 2, 278m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 42, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4570), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 17, 30, 2, 261m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 43, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 18, 35, 5, 64m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 44, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 18, 33, 4, 41m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 45, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 18, 27, 3, 389m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 46, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 18, 12, 4, 91m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 47, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 19, 6, 1, 201m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 48, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 20, 19, 5, 441m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 49, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 20, 3, 1, 285m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 50, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 20, 2, 5, 363m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 51, new DateTimeOffset(new DateTime(2025, 3, 16, 1, 32, 27, 787, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 20, 32, 1, 250m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiClients");

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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
