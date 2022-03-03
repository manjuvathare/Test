using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirLines.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightShedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    FromLocationId = table.Column<int>(type: "int", nullable: false),
                    ToLocationId = table.Column<int>(type: "int", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightShedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightShedule_Airline_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "Airline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightShedule_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightSheduleId = table.Column<int>(type: "int", nullable: false),
                    ReturnFlightSheduleId = table.Column<int>(type: "int", nullable: true),
                    BookingStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDetails_BookingStatus_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_FlightShedule_FlightSheduleId",
                        column: x => x.FlightSheduleId,
                        principalTable: "FlightShedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_BookingStatusId",
                table: "BookingDetails",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_FlightSheduleId",
                table: "BookingDetails",
                column: "FlightSheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightShedule_AirLineId",
                table: "FlightShedule",
                column: "AirLineId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightShedule_LocationId",
                table: "FlightShedule",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "FlightShedule");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
