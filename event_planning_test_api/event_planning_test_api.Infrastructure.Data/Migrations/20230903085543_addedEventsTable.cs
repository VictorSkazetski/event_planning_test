using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_planning_test_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JsonEvent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f67a2c8a-3afa-40e3-902d-c063a28b4358", "AQAAAAIAAYagAAAAEA3PuXgaB1yLmi+tF+v7CSd3dS6SV+Am4lh4+4fPN2uKfKlmX9RdeNoeKKQAbI5kKA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "427c864b-b185-48cf-82e1-948ce489ec3e", "AQAAAAIAAYagAAAAED7X3kaJH5MTOqpnBn05o5PkSawOCroDWqyuwNCzH7pcC5Ga4RpSxbNAh0OPeWVCXw==" });
        }
    }
}
