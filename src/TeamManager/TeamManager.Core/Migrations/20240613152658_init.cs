using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamManager.Core.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "DeveloperGame",
                columns: table => new
                {
                    DevelopersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperGame", x => new { x.DevelopersId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameLanguage",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLanguage", x => new { x.GamesId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_GameLanguage_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLanguage_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountPlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameAccounts_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameAccounts_Platforms_accountPlatformId",
                        column: x => x.accountPlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementsForSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    gameAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    advertisementStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementsForSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementsForSales_AdvertisementStatuses_advertisementStatusId",
                        column: x => x.advertisementStatusId,
                        principalTable: "AdvertisementStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvertisementsForSales_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvertisementsForSales_GameAccounts_gameAccountId",
                        column: x => x.gameAccountId,
                        principalTable: "GameAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameGameAccount",
                columns: table => new
                {
                    GameAccountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameAccount", x => new { x.GameAccountsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_GameGameAccount_GameAccounts_GameAccountsId",
                        column: x => x.GameAccountsId,
                        principalTable: "GameAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameAccount_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementsToFind",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    userGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementsToFind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementsToFind_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementToFindGame",
                columns: table => new
                {
                    AdvertisementsToFindId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementToFindGame", x => new { x.AdvertisementsToFindId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_AdvertisementToFindGame_AdvertisementsToFind_AdvertisementsToFindId",
                        column: x => x.AdvertisementsToFindId,
                        principalTable: "AdvertisementsToFind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementToFindGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    advertisementToFindId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_AdvertisementsToFind_advertisementToFindId",
                        column: x => x.advertisementToFindId,
                        principalTable: "AdvertisementsToFind",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserUserGroup",
                columns: table => new
                {
                    UserGroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserGroup", x => new { x.UserGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserUserGroup_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserGroup_UserGroups_UserGroupsId",
                        column: x => x.UserGroupsId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdvertisementStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("92df00a4-822c-4732-9904-5f98837c9056"), "For Rent" },
                    { new Guid("cd86ffa7-ef57-4031-9912-8b66f6968ec5"), "For Sale" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8169307e-6fe3-4727-9cd5-79f6ecc20d0b"), "8169307e-6fe3-4727-9cd5-79f6ecc20d0b", "Admin", "ADMIN" },
                    { new Guid("eb9dd9e4-39c9-4650-a561-10959715f1ed"), "eb9dd9e4-39c9-4650-a561-10959715f1ed", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("352cf391-77ea-415d-9457-632dba19b32c"), 0, "586b938c-e7ba-4426-bc95-ddc07abf1e37", "user1@example", true, "Tom Morgan", false, null, "USER1@EXAMPLE", "USER1@EXAMPLE", "AQAAAAIAAYagAAAAEL24LZbPBQRwY/Bu5HSjtIDfpIqviqDILfXh/FAffcO0e5QG5QFmKb1jmCT34AtaXA==", null, false, "a0856462-16a3-469f-a786-f3ca45fd7967", false, "user1@example" },
                    { new Guid("f79bc2a3-ce8b-4665-b84c-8e9f8f3d1fc8"), 0, "d7ab61e6-88e9-4dbe-9748-17bf6ba7b421", "admin@example", true, "Jack Rell", false, null, "ADMIN@EXAMPLE", "ADMIN@EXAMPLE", "AQAAAAIAAYagAAAAEGXls0it2IgvbSNopR0JFrJPf16iFET2zAMKAhIrCfsV7f5DylJB9YyJhm2vNUq2/Q==", null, false, "1c15d414-9720-4d1d-bf11-222a5bea4327", false, "admin@example" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15f30551-b127-42fa-b8a2-0ae25dcfaf2e"), "Activision Blizzard" },
                    { new Guid("541a2f7e-c379-4216-92bf-4f2dd81d4673"), "Valve Corporation" },
                    { new Guid("5fcadcbd-d7d2-4d92-9bd8-172cfb44e350"), "Electronic Arts" },
                    { new Guid("637ffc9b-c37d-447b-9bd0-6ab3747ad158"), "Square Enix" },
                    { new Guid("66ec9a49-1253-48c9-983d-b7b28e9a1ae0"), "Naughty Dog" },
                    { new Guid("679b1be9-f9ee-48d9-9a06-02259e226f4e"), "Ubisoft" },
                    { new Guid("74921198-0faf-43e4-8526-1aec2ac8f833"), "Rockstar Games" },
                    { new Guid("b8966b2f-6d19-4399-9281-bdb121816406"), "CD Projekt" },
                    { new Guid("c40bd541-3531-4132-9757-5437b755f946"), "Nintendo" },
                    { new Guid("cc93c261-b4d5-47ff-a5e1-410481ffc472"), "Epic Games" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06a41972-ef39-47bc-bd85-775a12b56f44"), "Action" },
                    { new Guid("13a5f0ad-f962-466c-a423-530f047e29d0"), "Horror" },
                    { new Guid("50b352e5-d5d3-4bfb-89f8-35d98ead7251"), "Simulation" },
                    { new Guid("627efb38-6c4d-4c99-9638-cc538a7d4b4f"), "Racing" },
                    { new Guid("639caea8-dbb1-4e9e-94b5-1247fd952e40"), "Adventure" },
                    { new Guid("65010ccf-e200-45b5-9670-926104138a17"), "Role-playing" },
                    { new Guid("75036812-712a-40b8-a5ee-2aaa7b86329a"), "Strategy" },
                    { new Guid("8556a959-19d9-4fd8-afbf-ea00b0e9f3b9"), "Puzzle" },
                    { new Guid("dd21f4fe-afa2-4f4d-9098-a4703ca1ef56"), "Fighting" },
                    { new Guid("fdc114a8-ab43-4c29-9b3b-968d9627d8ea"), "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17e649da-def5-4637-8f13-dac2d4ce264e"), "Korean" },
                    { new Guid("1a5eb16e-a1de-4f9f-bb39-3614b48081ea"), "German" },
                    { new Guid("3a845faa-95ac-4177-83a2-115a997e2612"), "Russian" },
                    { new Guid("420d448a-5a45-40dc-9278-13583611c341"), "French" },
                    { new Guid("94947646-3e19-4c6d-9e77-2ab95522caab"), "Japanese" },
                    { new Guid("9cc3bb54-9e4d-45fc-a44d-3635826bfc98"), "Spanish" },
                    { new Guid("b790dd13-9964-4918-8e73-bb05be0c96dd"), "Italian" },
                    { new Guid("cd9afa8f-8426-425d-b286-431da244707d"), "English" },
                    { new Guid("ecf6109b-33de-4f92-b701-9a40c1c071b1"), "Portuguese" },
                    { new Guid("f19788a8-c555-492d-b28e-ed29c114cf66"), "Chinese" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b98be6b-8279-41b4-a00d-44b5346d67c8"), "Mobile" },
                    { new Guid("26667bab-f3a2-44e7-89fb-badd744ea190"), "PlayStation 5" },
                    { new Guid("2e94722a-7bb7-4f46-b852-51bbf135ed7e"), "Xbox Series X" },
                    { new Guid("58dddb06-1d0f-4b6d-8a90-22c10a1acede"), "PC" },
                    { new Guid("7acac67f-cbdf-4418-9da7-a275d9788f9e"), "VR" },
                    { new Guid("7ec1322f-5a6f-43f1-a25f-ab15cf40390e"), "Nintendo Switch" },
                    { new Guid("9062a58e-eb83-42ff-97b4-7a5ec9d47827"), "PlayStation 4" },
                    { new Guid("be867c45-e679-41f9-8411-d08e7620eca3"), "Mac" },
                    { new Guid("d241252d-c2b0-4901-988e-bf54b4293435"), "Xbox One" },
                    { new Guid("d6909b00-44a0-4a62-91a2-defb681f2bec"), "Google Stadia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("eb9dd9e4-39c9-4650-a561-10959715f1ed"), new Guid("352cf391-77ea-415d-9457-632dba19b32c") },
                    { new Guid("8169307e-6fe3-4727-9cd5-79f6ecc20d0b"), new Guid("f79bc2a3-ce8b-4665-b84c-8e9f8f3d1fc8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementsForSales_advertisementStatusId",
                table: "AdvertisementsForSales",
                column: "advertisementStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementsForSales_gameAccountId",
                table: "AdvertisementsForSales",
                column: "gameAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementsForSales_userId",
                table: "AdvertisementsForSales",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementsToFind_userGroupId",
                table: "AdvertisementsToFind",
                column: "userGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementsToFind_userId",
                table: "AdvertisementsToFind",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementToFindGame_GamesId",
                table: "AdvertisementToFindGame",
                column: "GamesId");

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
                name: "IX_DeveloperGame_GamesId",
                table: "DeveloperGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameAccounts_accountPlatformId",
                table: "GameAccounts",
                column: "accountPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GameAccounts_userId",
                table: "GameAccounts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameAccount_GamesId",
                table: "GameGameAccount",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLanguage_LanguagesId",
                table: "GameLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_advertisementToFindId",
                table: "UserGroups",
                column: "advertisementToFindId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserGroup_UsersId",
                table: "UserUserGroup",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementsToFind_UserGroups_userGroupId",
                table: "AdvertisementsToFind",
                column: "userGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementsToFind_AspNetUsers_userId",
                table: "AdvertisementsToFind");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementsToFind_UserGroups_userGroupId",
                table: "AdvertisementsToFind");

            migrationBuilder.DropTable(
                name: "AdvertisementsForSales");

            migrationBuilder.DropTable(
                name: "AdvertisementToFindGame");

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
                name: "DeveloperGame");

            migrationBuilder.DropTable(
                name: "GameGameAccount");

            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "GameLanguage");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "UserUserGroup");

            migrationBuilder.DropTable(
                name: "AdvertisementStatuses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "GameAccounts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "AdvertisementsToFind");
        }
    }
}
