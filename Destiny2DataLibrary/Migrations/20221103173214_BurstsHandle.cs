using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class BurstsHandle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BurstStatsId",
                table: "Archetypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FramesBetweenShots",
                table: "Archetypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBurst",
                table: "Archetypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BurstStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BulletsInBurst = table.Column<int>(type: "integer", nullable: false),
                    FramesPerBurstt = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurstStats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archetypes_BurstStatsId",
                table: "Archetypes",
                column: "BurstStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_BurstStats_BurstStatsId",
                table: "Archetypes",
                column: "BurstStatsId",
                principalTable: "BurstStats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_BurstStats_BurstStatsId",
                table: "Archetypes");

            migrationBuilder.DropTable(
                name: "BurstStats");

            migrationBuilder.DropIndex(
                name: "IX_Archetypes_BurstStatsId",
                table: "Archetypes");

            migrationBuilder.DropColumn(
                name: "BurstStatsId",
                table: "Archetypes");

            migrationBuilder.DropColumn(
                name: "FramesBetweenShots",
                table: "Archetypes");

            migrationBuilder.DropColumn(
                name: "IsBurst",
                table: "Archetypes");
        }
    }
}
