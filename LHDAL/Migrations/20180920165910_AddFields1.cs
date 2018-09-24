using Microsoft.EntityFrameworkCore.Migrations;

namespace LHDAL.Migrations
{
    public partial class AddFields1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "LHUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LHUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "LHUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LHUser");
        }
    }
}
