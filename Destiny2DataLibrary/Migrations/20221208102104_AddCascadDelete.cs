using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuffStacks_ReloadStats_ReloadStatId",
                table: "BuffStacks");

            migrationBuilder.DropIndex(
                name: "IX_BuffStacks_ReloadStatId",
                table: "BuffStacks");

            migrationBuilder.DropColumn(
                name: "ReloadStatId",
                table: "BuffStacks");

            migrationBuilder.AlterColumn<int>(
                name: "PvpPrecisionBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PvpBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PvePrecisionBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PveBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PvpPrecisionBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PvpBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PvePrecisionBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PveBulletDamage",
                table: "ShotsDamage",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ReloadStatId",
                table: "BuffStacks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuffStacks_ReloadStatId",
                table: "BuffStacks",
                column: "ReloadStatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuffStacks_ReloadStats_ReloadStatId",
                table: "BuffStacks",
                column: "ReloadStatId",
                principalTable: "ReloadStats",
                principalColumn: "Id");
        }
    }
}
