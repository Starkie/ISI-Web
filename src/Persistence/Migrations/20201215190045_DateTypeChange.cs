using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotografos.Persistence.Migrations
{
    public partial class DateTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    equimentDescription = table.Column<string>(type: "TEXT", nullable: false),
                    resume = table.Column<string>(type: "TEXT", nullable: false),
                    photographerId = table.Column<long>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Photographer",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    surename = table.Column<string>(type: "TEXT", nullable: false),
                    addess = table.Column<string>(type: "TEXT", nullable: false),
                    city = table.Column<string>(type: "TEXT", nullable: false),
                    postalcode = table.Column<long>(type: "INT", nullable: false),
                    telephone = table.Column<long>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographer", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Photographer");
        }
    }
}
