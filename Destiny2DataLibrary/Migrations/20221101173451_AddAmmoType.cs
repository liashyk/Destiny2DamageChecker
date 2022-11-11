using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class AddAmmoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmmoTypeId",
                table: "Archetypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AmmoType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmoType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archetypes_AmmoTypeId",
                table: "Archetypes",
                column: "AmmoTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_AmmoType_AmmoTypeId",
                table: "Archetypes",
                column: "AmmoTypeId",
                principalTable: "AmmoType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_AmmoType_AmmoTypeId",
                table: "Archetypes");

            migrationBuilder.DropTable(
                name: "AmmoType");

            migrationBuilder.DropIndex(
                name: "IX_Archetypes_AmmoTypeId",
                table: "Archetypes");

            migrationBuilder.DropColumn(
                name: "AmmoTypeId",
                table: "Archetypes");
        }
    }
}
