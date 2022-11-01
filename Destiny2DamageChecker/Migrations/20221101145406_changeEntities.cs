using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class changeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShotsDamage_Archetypes_ArchetypeId",
                table: "ShotsDamage");

            migrationBuilder.DropTable(
                name: "ArchetypePerk");

            migrationBuilder.DropIndex(
                name: "IX_ShotsDamage_ArchetypeId",
                table: "ShotsDamage");

            migrationBuilder.DropColumn(
                name: "ArchetypeId",
                table: "ShotsDamage");

            migrationBuilder.AddColumn<int>(
                name: "ArchetypeId",
                table: "Perks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShotDamageId",
                table: "Archetypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perks_ArchetypeId",
                table: "Perks",
                column: "ArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Archetypes_ShotDamageId",
                table: "Archetypes",
                column: "ShotDamageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_ShotsDamage_ShotDamageId",
                table: "Archetypes",
                column: "ShotDamageId",
                principalTable: "ShotsDamage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Perks_Archetypes_ArchetypeId",
                table: "Perks",
                column: "ArchetypeId",
                principalTable: "Archetypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_ShotsDamage_ShotDamageId",
                table: "Archetypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Perks_Archetypes_ArchetypeId",
                table: "Perks");

            migrationBuilder.DropIndex(
                name: "IX_Perks_ArchetypeId",
                table: "Perks");

            migrationBuilder.DropIndex(
                name: "IX_Archetypes_ShotDamageId",
                table: "Archetypes");

            migrationBuilder.DropColumn(
                name: "ArchetypeId",
                table: "Perks");

            migrationBuilder.DropColumn(
                name: "ShotDamageId",
                table: "Archetypes");

            migrationBuilder.AddColumn<int>(
                name: "ArchetypeId",
                table: "ShotsDamage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_ShotsDamage_ArchetypeId",
                table: "ShotsDamage",
                column: "ArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypePerk_PerksId",
                table: "ArchetypePerk",
                column: "PerksId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShotsDamage_Archetypes_ArchetypeId",
                table: "ShotsDamage",
                column: "ArchetypeId",
                principalTable: "Archetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
