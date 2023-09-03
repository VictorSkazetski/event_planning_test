using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_planning_test_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedUserCountColumnToEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCount",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7af31bec-c5fc-451b-98c6-e28bd754c704", "AQAAAAIAAYagAAAAEMZC8IDVqUKrbKZyqxDOA7pDn8hvtpocAnb/OtKpD+zO5dpjRMJ3b5upqsFvRO/u3Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCount",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f67a2c8a-3afa-40e3-902d-c063a28b4358", "AQAAAAIAAYagAAAAEA3PuXgaB1yLmi+tF+v7CSd3dS6SV+Am4lh4+4fPN2uKfKlmX9RdeNoeKKQAbI5kKA==" });
        }
    }
}
