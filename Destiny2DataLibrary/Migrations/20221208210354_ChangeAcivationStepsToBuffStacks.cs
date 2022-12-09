using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAcivationStepsToBuffStacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivationStepsAmount",
                table: "Perks",
                newName: "BuffStacksAmount");

            migrationBuilder.RenameColumn(
                name: "ActivationStepsAmount",
                table: "DamageBuffs",
                newName: "BuffStacksAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuffStacksAmount",
                table: "Perks",
                newName: "ActivationStepsAmount");

            migrationBuilder.RenameColumn(
                name: "BuffStacksAmount",
                table: "DamageBuffs",
                newName: "ActivationStepsAmount");
        }
    }
}
