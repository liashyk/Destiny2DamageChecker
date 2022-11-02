using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class ManyToManyPerks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perks_Archetypes_ArchetypeId",
                table: "Perks");

            migrationBuilder.DropIndex(
                name: "IX_Perks_ArchetypeId",
                table: "Perks");

            migrationBuilder.DropColumn(
                name: "ArchetypeId",
                table: "Perks");

            migrationBuilder.CreateTable(
                name: "ArchetypePerk",
                columns: table => new
                {
                    ArchetypesId = table.Column<int>(type: "integer", nullable: false),
                    PerksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchetypePerk", x => new { x.ArchetypesId, x.PerksId });
                    table.ForeignKey(
                        name: "FK_ArchetypePerk_Archetypes_ArchetypesId",
                        column: x => x.ArchetypesId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchetypePerk_Perks_PerksId",
                        column: x => x.PerksId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypePerk_PerksId",
                table: "ArchetypePerk",
                column: "PerksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchetypePerk");

            migrationBuilder.AddColumn<int>(
                name: "ArchetypeId",
                table: "Perks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perks_ArchetypeId",
                table: "Perks",
                column: "ArchetypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perks_Archetypes_ArchetypeId",
                table: "Perks",
                column: "ArchetypeId",
                principalTable: "Archetypes",
                principalColumn: "Id");
        }
    }
}
