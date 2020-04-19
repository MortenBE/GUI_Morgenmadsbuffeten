using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet_GUI.Data.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuffetReservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(nullable: false),
                    NumberOfChildren = table.Column<int>(nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false),
                    CheckedIn = table.Column<bool>(nullable: false, defaultValue: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetReservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuffetReservations");
        }
    }
}
