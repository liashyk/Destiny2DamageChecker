using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class AddAmmoTypeSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_AmmoType_AmmoTypeId",
                table: "Archetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmmoType",
                table: "AmmoType");

            migrationBuilder.RenameTable(
                name: "AmmoType",
                newName: "AmmoTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmmoTypes",
                table: "AmmoTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_AmmoTypes_AmmoTypeId",
                table: "Archetypes",
                column: "AmmoTypeId",
                principalTable: "AmmoTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_AmmoTypes_AmmoTypeId",
                table: "Archetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmmoTypes",
                table: "AmmoTypes");

            migrationBuilder.RenameTable(
                name: "AmmoTypes",
                newName: "AmmoType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmmoType",
                table: "AmmoType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_AmmoType_AmmoTypeId",
                table: "Archetypes",
                column: "AmmoTypeId",
                principalTable: "AmmoType",
                principalColumn: "Id");
        }
    }
}
