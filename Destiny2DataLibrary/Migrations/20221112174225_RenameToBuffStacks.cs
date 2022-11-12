using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class RenameToBuffStacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_ReloadStats_ReloadStatId",
                table: "ActivationSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivationSteps",
                table: "ActivationSteps");

            migrationBuilder.RenameTable(
                name: "ActivationSteps",
                newName: "BuffStacks");

            migrationBuilder.RenameIndex(
                name: "IX_ActivationSteps_ReloadStatId",
                table: "BuffStacks",
                newName: "IX_BuffStacks_ReloadStatId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivationSteps_PerkId",
                table: "BuffStacks",
                newName: "IX_BuffStacks_PerkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuffStacks",
                table: "BuffStacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuffStacks_Perks_PerkId",
                table: "BuffStacks",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuffStacks_ReloadStats_ReloadStatId",
                table: "BuffStacks",
                column: "ReloadStatId",
                principalTable: "ReloadStats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuffStacks_Perks_PerkId",
                table: "BuffStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_BuffStacks_ReloadStats_ReloadStatId",
                table: "BuffStacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuffStacks",
                table: "BuffStacks");

            migrationBuilder.RenameTable(
                name: "BuffStacks",
                newName: "ActivationSteps");

            migrationBuilder.RenameIndex(
                name: "IX_BuffStacks_ReloadStatId",
                table: "ActivationSteps",
                newName: "IX_ActivationSteps_ReloadStatId");

            migrationBuilder.RenameIndex(
                name: "IX_BuffStacks_PerkId",
                table: "ActivationSteps",
                newName: "IX_ActivationSteps_PerkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivationSteps",
                table: "ActivationSteps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationSteps_Perks_PerkId",
                table: "ActivationSteps",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationSteps_ReloadStats_ReloadStatId",
                table: "ActivationSteps",
                column: "ReloadStatId",
                principalTable: "ReloadStats",
                principalColumn: "Id");
        }
    }
}
