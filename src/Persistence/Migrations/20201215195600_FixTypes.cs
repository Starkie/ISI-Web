using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotografos.Persistence.Migrations
{
    public partial class FixTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "equimentDescription",
                table: "Application",
                newName: "equipmentDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "equipmentDescription",
                table: "Application",
                newName: "equimentDescription");
        }
    }
}
