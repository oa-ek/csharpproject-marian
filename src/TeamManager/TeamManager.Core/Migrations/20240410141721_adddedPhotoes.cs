using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManager.Core.Migrations
{
    /// <inheritdoc />
    public partial class adddedPhotoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GamePhoto",
                table: "Games",
                newName: "MainImage");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "UserGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "AdvertisementsForSales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "AdvertisementsForSales");

            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "Games",
                newName: "GamePhoto");
        }
    }
}
