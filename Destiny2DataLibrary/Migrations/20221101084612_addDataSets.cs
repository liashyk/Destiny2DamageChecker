using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class addDataSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_WeaponType_WeaponTypeId",
                table: "Archetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeaponType",
                table: "WeaponType");

            migrationBuilder.RenameTable(
                name: "WeaponType",
                newName: "WeaponTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeaponTypes",
                table: "WeaponTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_WeaponTypes_WeaponTypeId",
                table: "Archetypes",
                column: "WeaponTypeId",
                principalTable: "WeaponTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_WeaponTypes_WeaponTypeId",
                table: "Archetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeaponTypes",
                table: "WeaponTypes");

            migrationBuilder.RenameTable(
                name: "WeaponTypes",
                newName: "WeaponType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeaponType",
                table: "WeaponType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_WeaponType_WeaponTypeId",
                table: "Archetypes",
                column: "WeaponTypeId",
                principalTable: "WeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
