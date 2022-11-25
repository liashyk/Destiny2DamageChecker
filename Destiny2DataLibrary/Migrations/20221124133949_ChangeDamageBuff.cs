using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class ChangeDamageBuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DamageBuffs");

            migrationBuilder.AddColumn<int>(
                name: "ActivationStepsAmount",
                table: "DamageBuffs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "DamageBuffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DamageBuffId",
                table: "BuffStacks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuffStacks_DamageBuffId",
                table: "BuffStacks",
                column: "DamageBuffId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuffStacks_DamageBuffs_DamageBuffId",
                table: "BuffStacks",
                column: "DamageBuffId",
                principalTable: "DamageBuffs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuffStacks_DamageBuffs_DamageBuffId",
                table: "BuffStacks");

            migrationBuilder.DropIndex(
                name: "IX_BuffStacks_DamageBuffId",
                table: "BuffStacks");

            migrationBuilder.DropColumn(
                name: "ActivationStepsAmount",
                table: "DamageBuffs");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "DamageBuffs");

            migrationBuilder.DropColumn(
                name: "DamageBuffId",
                table: "BuffStacks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DamageBuffs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
