using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_planning_test_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedUserJoinEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserJoinEvents",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJoinEvents", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserJoinEvents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJoinEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b8caf2b-7c84-43a4-8566-66380f3ce42d", "AQAAAAIAAYagAAAAEHmz+YOhfQnaPn2B/gPUx3958cNJsaJAzp/XfytTnOm7jqedGPnajD2eoKfXnk+czA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserJoinEvents_EventId",
                table: "UserJoinEvents",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJoinEvents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7af31bec-c5fc-451b-98c6-e28bd754c704", "AQAAAAIAAYagAAAAEMZC8IDVqUKrbKZyqxDOA7pDn8hvtpocAnb/OtKpD+zO5dpjRMJ3b5upqsFvRO/u3Q==" });
        }
    }
}
