using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class weaponTypeArchetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.AddColumn<string>(
                name: "WeaponType",
                table: "Archetypes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PerkId",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.DropColumn(
                name: "WeaponType",
                table: "Archetypes");

            migrationBuilder.AlterColumn<int>(
                name: "PerkId",
                table: "ActivationSteps",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id");
        }
    }
}
