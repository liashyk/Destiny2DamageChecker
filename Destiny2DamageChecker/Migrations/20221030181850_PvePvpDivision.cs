using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class PvePvpDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.DropColumn(
                name: "IsPvpVersion",
                table: "Perks");

            migrationBuilder.RenameColumn(
                name: "DamageBuffPercent",
                table: "ActivationSteps",
                newName: "PvpRapidFireBuffPercent");

            migrationBuilder.AlterColumn<int>(
                name: "PerkId",
                table: "ActivationSteps",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PveDamageBuffPercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PveRapidFirePercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PvpDamageBuffPercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.DropColumn(
                name: "PveDamageBuffPercent",
                table: "ActivationSteps");

            migrationBuilder.DropColumn(
                name: "PveRapidFirePercent",
                table: "ActivationSteps");

            migrationBuilder.DropColumn(
                name: "PvpDamageBuffPercent",
                table: "ActivationSteps");

            migrationBuilder.RenameColumn(
                name: "PvpRapidFireBuffPercent",
                table: "ActivationSteps",
                newName: "DamageBuffPercent");

            migrationBuilder.AddColumn<bool>(
                name: "IsPvpVersion",
                table: "Perks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
    }
}
