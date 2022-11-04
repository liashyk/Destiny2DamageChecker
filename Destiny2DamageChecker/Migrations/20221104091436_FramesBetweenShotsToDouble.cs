using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class FramesBetweenShotsToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_ShotsDamage_ShotDamageId",
                table: "Archetypes");

            migrationBuilder.AlterColumn<int>(
                name: "ShotDamageId",
                table: "Archetypes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FramesBetweenShots",
                table: "Archetypes",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_ShotsDamage_ShotDamageId",
                table: "Archetypes",
                column: "ShotDamageId",
                principalTable: "ShotsDamage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archetypes_ShotsDamage_ShotDamageId",
                table: "Archetypes");

            migrationBuilder.AlterColumn<int>(
                name: "ShotDamageId",
                table: "Archetypes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FramesBetweenShots",
                table: "Archetypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_Archetypes_ShotsDamage_ShotDamageId",
                table: "Archetypes",
                column: "ShotDamageId",
                principalTable: "ShotsDamage",
                principalColumn: "Id");
        }
    }
}
