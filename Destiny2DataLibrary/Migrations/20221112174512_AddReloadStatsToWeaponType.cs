using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class AddReloadStatsToWeaponType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReloadStatsId",
                table: "WeaponTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeaponTypes_ReloadStatsId",
                table: "WeaponTypes",
                column: "ReloadStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponTypes_ReloadStats_ReloadStatsId",
                table: "WeaponTypes",
                column: "ReloadStatsId",
                principalTable: "ReloadStats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeaponTypes_ReloadStats_ReloadStatsId",
                table: "WeaponTypes");

            migrationBuilder.DropIndex(
                name: "IX_WeaponTypes_ReloadStatsId",
                table: "WeaponTypes");

            migrationBuilder.DropColumn(
                name: "ReloadStatsId",
                table: "WeaponTypes");
        }
    }
}
