using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    public partial class AddPvpVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPvpVersion",
                table: "Perks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPvpVersion",
                table: "Perks");
        }
    }
}
