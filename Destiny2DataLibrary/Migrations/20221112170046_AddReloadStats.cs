using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class AddReloadStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReloadStatId",
                table: "ActivationSteps",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReloadStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    a = table.Column<double>(type: "double precision", nullable: false),
                    b = table.Column<double>(type: "double precision", nullable: false),
                    c = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReloadStats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivationSteps_ReloadStatId",
                table: "ActivationSteps",
                column: "ReloadStatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationSteps_ReloadStats_ReloadStatId",
                table: "ActivationSteps",
                column: "ReloadStatId",
                principalTable: "ReloadStats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivationSteps_ReloadStats_ReloadStatId",
                table: "ActivationSteps");

            migrationBuilder.DropTable(
                name: "ReloadStats");

            migrationBuilder.DropIndex(
                name: "IX_ActivationSteps_ReloadStatId",
                table: "ActivationSteps");

            migrationBuilder.DropColumn(
                name: "ReloadStatId",
                table: "ActivationSteps");
        }
    }
}
