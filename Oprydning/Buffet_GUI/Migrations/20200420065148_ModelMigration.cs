using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet_GUI.Migrations
{
    public partial class ModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CheckedInGuests",
                columns: new[] { "RoomNumber", "Date", "NumberOfAdultsCheckedIn", "NumberOfChildrenCheckedIn" },
                values: new object[] { 22, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Local), 10, 6 });

            migrationBuilder.InsertData(
                table: "CheckedInGuests",
                columns: new[] { "RoomNumber", "Date", "NumberOfAdultsCheckedIn", "NumberOfChildrenCheckedIn" },
                values: new object[] { 14, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Local), 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckedInGuests",
                keyColumns: new[] { "RoomNumber", "Date" },
                keyValues: new object[] { 14, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.DeleteData(
                table: "CheckedInGuests",
                keyColumns: new[] { "RoomNumber", "Date" },
                keyValues: new object[] { 22, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
