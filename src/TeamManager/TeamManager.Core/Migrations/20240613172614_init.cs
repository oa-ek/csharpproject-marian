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
                    { new Guid("228670e3-5834-4f2f-aca9-714fe6f83a69"), "For Sale" },
                    { new Guid("940c21f9-199f-4141-b472-fd09e956d5de"), "For Rent" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("32ccee4d-daa8-4021-a9f1-352cceafa207"), "32ccee4d-daa8-4021-a9f1-352cceafa207", "Admin", "ADMIN" },
                    { new Guid("d01711c8-b8ab-4446-a475-913d35917369"), "d01711c8-b8ab-4446-a475-913d35917369", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("ce14fdbb-c6b0-48ed-b1be-758ef6ed6392"), 0, "2128a94e-6c6d-4468-a775-7f1ea55da05b", "user1@example", true, "Tom Morgan", false, null, "USER1@EXAMPLE", "USER1@EXAMPLE", "AQAAAAIAAYagAAAAEF6ejgPKQgn81WL8YKN9JUlEITAgcLhVTv6dpIVttg/hTdnVrFtU4EnMf3u7fWCKGA==", null, false, "4e4794e6-916a-4e9b-8b61-80061c9eb6c1", false, "user1@example" },
                    { new Guid("fcfc8ca2-8d03-427f-a89b-0f0651fcfaec"), 0, "7eae8844-dac7-4863-b404-ca85e1513879", "admin@example", true, "Jack Rell", false, null, "ADMIN@EXAMPLE", "ADMIN@EXAMPLE", "AQAAAAIAAYagAAAAEEXxv3nK5pI9XokfpZQ45k/mXwO0TnCJlVW7CrKa/QDOJKwjfQVPoMK8xEGllZ0fPA==", null, false, "91432000-c331-478a-be0d-2901d7b772e9", false, "admin@example" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("39272d3d-e346-461a-a66c-fcffc056bfbc"), "Ubisoft" },
                    { new Guid("55e3270e-4374-4dec-b018-df485d5b1e6c"), "Valve Corporation" },
                    { new Guid("78919e1a-839a-41b1-b79e-6561f3f34909"), "Nintendo" },
                    { new Guid("8407af0d-c8db-4a95-a5d8-d4a1f0bb0b26"), "Square Enix" },
                    { new Guid("ac10c893-3bca-495e-b1d4-529123f7b22e"), "CD Projekt" },
                    { new Guid("c3846bf7-84d1-424d-a7f7-5061fe6ddb98"), "Rockstar Games" },
                    { new Guid("dc9bff50-2eea-444a-83c7-caad3027e031"), "Activision Blizzard" },
                    { new Guid("e9f0594c-388c-4d25-a1c2-864a90a2449c"), "Epic Games" },
                    { new Guid("ea088839-590a-414d-9d85-feaa2cc49f25"), "Naughty Dog" },
                    { new Guid("f46d6514-9204-4f92-968e-d54f67569c4a"), "Electronic Arts" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("055e5d0b-f8e5-477d-831c-f3ebc97fbdbc"), "Racing" },
                    { new Guid("08e1cde1-331d-4916-939d-6bc0b4efecb0"), "Adventure" },
                    { new Guid("117ffaa5-56fc-49f7-ba7e-5f68dfffe5c4"), "Action" },
                    { new Guid("4e024ec7-2f7e-4570-829f-7ee4b00cdad2"), "Simulation" },
                    { new Guid("8599a34d-7c6a-4916-b129-abd99e8482ac"), "Puzzle" },
                    { new Guid("874458e6-54f3-40cf-9694-dde5ced7e120"), "Fighting" },
                    { new Guid("9fa6bcd6-20a8-4175-afed-51b1011a2027"), "Horror" },
                    { new Guid("cb28ea67-3b18-4aa6-a104-ffc6deb03b26"), "Sports" },
                    { new Guid("fbb92226-2091-4b1b-b4d8-1388812738e7"), "Strategy" },
                    { new Guid("fefd611c-45a9-4309-9892-66480dd8b49d"), "Role-playing" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0996d1a1-1363-453b-a30e-5f24961ddffe"), "Spanish" },
                    { new Guid("46888ef9-7155-4fec-85bd-76741e03cb5c"), "Russian" },
                    { new Guid("651c67a1-81a4-4854-ad7e-35d2f139ac24"), "Portuguese" },
                    { new Guid("83115919-8f32-401d-b147-8bca818ae72d"), "French" },
                    { new Guid("b135b596-5528-4e29-b06d-166b00af5cc5"), "Chinese" },
                    { new Guid("c7f61d58-a9bc-4009-a8a6-23d9f70eab6f"), "English" },
                    { new Guid("c827bb14-9bf6-4d47-9456-3c10d9021d9e"), "German" },
                    { new Guid("d3754cce-ea43-4129-ba62-ba7e32595829"), "Italian" },
                    { new Guid("e1a024b8-4cb3-46ca-8017-faec5e75298b"), "Japanese" },
                    { new Guid("e8de756c-a348-4402-a718-eb2f0c476c4a"), "Korean" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("116e5b6b-232d-451f-be59-5b9d54241333"), "Mac" },
                    { new Guid("11efca48-9c17-4de7-85ce-5fa759674adb"), "PC" },
                    { new Guid("3a1a851c-ffe9-4508-aad3-650ff9873079"), "Xbox One" },
                    { new Guid("6c60d854-931b-4798-95d0-c8f17806b64e"), "Nintendo Switch" },
                    { new Guid("7722a57a-dfa1-4427-aa6b-39462948187b"), "Xbox Series X" },
                    { new Guid("d6122068-d42f-412e-89b9-84191b253708"), "PlayStation 4" },
                    { new Guid("e011d7b3-eaea-4948-ada5-df9f0e6d81a2"), "PlayStation 5" },
                    { new Guid("e4639d87-b513-43ad-9e46-8203fc228f9c"), "Mobile" },
                    { new Guid("e82bbf89-b832-441a-9a99-1ee3f408d939"), "VR" },
                    { new Guid("f055e144-66f2-477f-993c-6b4c7c469e32"), "Google Stadia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d01711c8-b8ab-4446-a475-913d35917369"), new Guid("ce14fdbb-c6b0-48ed-b1be-758ef6ed6392") },
                    { new Guid("32ccee4d-daa8-4021-a9f1-352cceafa207"), new Guid("fcfc8ca2-8d03-427f-a89b-0f0651fcfaec") }
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
