using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBurstStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FramesPerBurstt",
                table: "BurstStats",
                newName: "FramesPerBurst");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FramesPerBurst",
                table: "BurstStats",
                newName: "FramesPerBurstt");
        }
    }
}
