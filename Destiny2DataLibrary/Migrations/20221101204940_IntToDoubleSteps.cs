using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class IntToDoubleSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.AlterColumn<double>(
                name: "PvpRapidFireBuffPercent",
                table: "ActivationSteps",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "PvpDamageBuffPercent",
                table: "ActivationSteps",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "PveRapidFirePercent",
                table: "ActivationSteps",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "PveDamageBuffPercent",
                table: "ActivationSteps",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.AlterColumn<int>(
                name: "PvpRapidFireBuffPercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "PvpDamageBuffPercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "PveRapidFirePercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "PveDamageBuffPercent",
                table: "ActivationSteps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

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
