using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class ShotDamage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BulletDamage",
                table: "Archetypes");

            migrationBuilder.CreateTable(
                name: "ShotsDamage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArchetypeId = table.Column<int>(type: "integer", nullable: false),
                    PveBulletDamage = table.Column<int>(type: "integer", nullable: true),
                    PvePrecisionBulletDamage = table.Column<int>(type: "integer", nullable: true),
                    PvpBulletDamage = table.Column<int>(type: "integer", nullable: true),
                    PvpPrecisionBulletDamage = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotsDamage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotsDamage_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShotsDamage_ArchetypeId",
                table: "ShotsDamage",
                column: "ArchetypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShotsDamage");

            migrationBuilder.AddColumn<int>(
                name: "BulletDamage",
                table: "Archetypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
