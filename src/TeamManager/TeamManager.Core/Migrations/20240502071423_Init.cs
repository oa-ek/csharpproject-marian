using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamManager.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
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
                name: "AdvertisementsToFind",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.InsertData(
                table: "AdvertisementStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b7284f9-bab0-4a8e-9aa7-f592a41ea0ec"), "For Rent" },
                    { new Guid("8404f287-1749-4078-b801-b602bd195c65"), "For Sale" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("45a782ae-6283-4547-a692-5c951ad8bdd5"), "45a782ae-6283-4547-a692-5c951ad8bdd5", "Admin", "ADMIN" },
                    { new Guid("61584baa-c843-4a17-a17b-468842c3639f"), "61584baa-c843-4a17-a17b-468842c3639f", "Finder", "FINDER" },
                    { new Guid("f30e87bc-e432-4efc-8b4c-6d6d57b5a78a"), "f30e87bc-e432-4efc-8b4c-6d6d57b5a78a", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1aa9cc56-12e3-44b8-b2b3-aefb4792a04e"), 0, "a6b29972-ef56-4f8c-8cd9-f5808f6dedbc", "teacher@projects.kleban.page", true, "Іван Петренко", false, null, "TEACHER@PROJECTS.KLEBAN.PAGE", "TEACHER@PROJECTS.KLEBAN.PAGE", "AQAAAAIAAYagAAAAEBiM08lRLuQ0Sgdk70jo6YSubQL3hLySWVI4ai7aFfLyBxiaCi4DP+/wiFy5GQSF0Q==", null, false, "e06dbaac-8ce9-45cf-9ff8-11c9a8ae9aef", false, "teacher@projects.kleban.page" },
                    { new Guid("3fe97f4d-88cc-4b8e-b6c8-498fcc9f6ec6"), 0, "b8bb4f1d-0d8e-42dc-9258-1b5bfa326ae6", "admin@projects.kleban.page", true, "Юрій Клебан", false, null, "ADMIN@PROJECTS.KLEBAN.PAGE", "ADMIN@PROJECTS.KLEBAN.PAGE", "AQAAAAIAAYagAAAAEH+DfgErrY7vva+bcXnpYva61k+J5Fv0n1vbxJ1Jln20YmGpXUgJHsMVNECkXMuoeg==", null, false, "1a2f5060-8cf8-44f6-a5b6-bf576d19bfa0", false, "admin@projects.kleban.page" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0aeb4110-11ef-4209-9233-00d2be47f0fb"), "Activision Blizzard" },
                    { new Guid("17dfbdf2-7a34-4f29-b4c2-31c0abc758ca"), "Electronic Arts" },
                    { new Guid("3096b5a9-332c-41c8-9019-b9e708b67ff8"), "Valve Corporation" },
                    { new Guid("692777b7-5721-49df-a4bd-a76a838a12aa"), "Naughty Dog" },
                    { new Guid("7c5d2c0e-4cf5-4b22-8cf5-afe1bf10e06b"), "CD Projekt" },
                    { new Guid("8a74fbaa-052f-4edc-af8d-a9ef61831421"), "Square Enix" },
                    { new Guid("a4aa6f1b-30bf-43c0-a904-95ca2aa840be"), "Ubisoft" },
                    { new Guid("b59c1875-516a-4220-bd4f-0c68fea59d98"), "Rockstar Games" },
                    { new Guid("d15165f3-0b48-4b18-a424-362c5b28bebb"), "Nintendo" },
                    { new Guid("f5ba7e89-669e-451e-8798-d31616a183a7"), "Epic Games" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("47cc8e7f-cc3a-4eed-bd68-6a7362adfe35"), "Sports" },
                    { new Guid("614e6460-7b22-40c2-a554-f6963673ab87"), "Horror" },
                    { new Guid("6cdd6ddf-e1c2-421f-af51-3295d239810e"), "Strategy" },
                    { new Guid("8a43adeb-e76e-484c-8271-491594ec91d7"), "Adventure" },
                    { new Guid("8c27a891-99ec-4be6-98ca-e6fdf0879c04"), "Simulation" },
                    { new Guid("90bbe734-c8ed-45d4-bbf4-eb35508beea5"), "Role-playing" },
                    { new Guid("9d291527-a4c1-4589-81cf-e15adb4403d8"), "Racing" },
                    { new Guid("c92de8f1-2d15-4957-92eb-9647a53421ff"), "Puzzle" },
                    { new Guid("f1fa89be-9de6-4ca6-8c76-d27908ead91a"), "Action" },
                    { new Guid("f8922d6f-42e0-4815-82dd-d8b15ab2a918"), "Fighting" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("183d8e83-a40f-4b6f-a8f3-088b8622fa5a"), "Korean" },
                    { new Guid("3f0a10f0-d896-4c37-a7c0-9354fc95e769"), "Chinese" },
                    { new Guid("47089659-0fa2-4a1e-814c-5d0e33473d29"), "German" },
                    { new Guid("581204b4-232c-4547-8077-815c8c45e80c"), "Russian" },
                    { new Guid("5e72adf2-87c9-4d3a-bc7b-5dbfb6305b5b"), "English" },
                    { new Guid("6b4d3fe1-896d-4ac1-9c66-00c5dbf380c3"), "Portuguese" },
                    { new Guid("a9b428f9-5db6-4c7d-8ebe-b1e0a5a98cb2"), "Italian" },
                    { new Guid("b38677d1-40c7-40e3-8c8a-c4e3c27aeade"), "French" },
                    { new Guid("cf853273-e363-4f86-adb6-7a6fcd20f9e6"), "Japanese" },
                    { new Guid("e7804577-4848-42aa-a08f-281b29eb4ecd"), "Spanish" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1316f9a3-ca53-4d81-ad2d-d390db9abe67"), "PlayStation 5" },
                    { new Guid("1865fe98-2950-4c53-84de-1d82f73eeeb6"), "VR" },
                    { new Guid("464a73e8-b515-4769-b3ee-5098c836d8a9"), "PlayStation 4" },
                    { new Guid("7d6f0b84-ca67-4dc8-8e70-5934cc835761"), "PC" },
                    { new Guid("9b9c7101-68d2-4320-b36f-92690b740b8e"), "Mac" },
                    { new Guid("a65c4f91-140b-44ea-a705-5022259297c8"), "Google Stadia" },
                    { new Guid("b0c36c00-85bf-4ba3-8451-e9d155e35adc"), "Nintendo Switch" },
                    { new Guid("b96ad9f2-c1e1-444d-9cbe-b93e3b0e53be"), "Mobile" },
                    { new Guid("c38efca0-1f12-423d-8c55-3774d44f15cc"), "Xbox One" },
                    { new Guid("c5e95b96-666e-46f2-bb2f-5f9319b0fdbc"), "Xbox Series X" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("45a782ae-6283-4547-a692-5c951ad8bdd5"), new Guid("3fe97f4d-88cc-4b8e-b6c8-498fcc9f6ec6") },
                    { new Guid("61584baa-c843-4a17-a17b-468842c3639f"), new Guid("3fe97f4d-88cc-4b8e-b6c8-498fcc9f6ec6") }
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
                name: "IX_UserUserGroup_UsersId",
                table: "UserUserGroup",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AdvertisementsToFind");

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
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
