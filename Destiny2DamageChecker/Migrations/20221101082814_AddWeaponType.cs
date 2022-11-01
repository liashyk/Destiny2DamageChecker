using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class AddWeaponType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeaponType",
                table: "Archetypes");

            migrationBuilder.AddColumn<int>(
                name: "WeaponTypeId",
                table: "Archetypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WeaponType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archetypes_WeaponTypeId",
                table: "Archetypes",
                column: "WeaponTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_WeaponType_WeaponTypeId",
                table: "Archetypes",
                column: "WeaponTypeId",
                principalTable: "WeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_WeaponType_WeaponTypeId",
                table: "Archetypes");

            migrationBuilder.DropTable(
                name: "WeaponType");

            migrationBuilder.DropIndex(
                name: "IX_Archetypes_WeaponTypeId",
                table: "Archetypes");

            migrationBuilder.DropColumn(
                name: "WeaponTypeId",
                table: "Archetypes");

            migrationBuilder.AddColumn<string>(
                name: "WeaponType",
                table: "Archetypes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
