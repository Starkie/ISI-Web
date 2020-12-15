using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotografos.Persistence.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "addess",
                table: "Photographer",
                newName: "address");

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "id", "date", "equimentDescription", "photographerId", "resume" },
                values: new object[] { 1L, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two cameras", 1L, "Photographer at a wedding" });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "id", "date", "equimentDescription", "photographerId", "resume" },
                values: new object[] { 2L, new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two cameras and tripod", 2L, "Nature photographer" });

            migrationBuilder.InsertData(
                table: "Photographer",
                columns: new[] { "id", "address", "city", "name", "postalcode", "surename", "telephone" },
                values: new object[] { 1L, "C/Falsa 123", "Pueblo Falso", "Juan", 46448L, "Augusto", 456456465L });

            migrationBuilder.InsertData(
                table: "Photographer",
                columns: new[] { "id", "address", "city", "name", "postalcode", "surename", "telephone" },
                values: new object[] { 2L, "C/Falsa 456", "Ciudad Falsa", "Carlos", 46444L, "Murcia", 456456464L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Photographer",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Photographer",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Photographer",
                newName: "addess");
        }
    }
}
