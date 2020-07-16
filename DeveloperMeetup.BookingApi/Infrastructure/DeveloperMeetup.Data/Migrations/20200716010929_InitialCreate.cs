using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperMeetup.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 10, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EventStatus = table.Column<bool>(nullable: false),
                    PricePerSession = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaxSeatAvailableforBooking = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TotalSeats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
                    SeatId = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalSeats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
                    ReservationId = table.Column<Guid>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ReservationPaymentId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<long>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ScheduledEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "ScheduledEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_RegisteredUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservedSeats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateUtc = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
                    SeatId = table.Column<string>(nullable: true),
                    EventId = table.Column<long>(nullable: false),
                    ReservationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ReservationId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservedSeats_ScheduledEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "ScheduledEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedSeats_Reservations_ReservationId1",
                        column: x => x.ReservationId1,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EventId",
                table: "Reservations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeats_EventId",
                table: "ReservedSeats",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeats_ReservationId1",
                table: "ReservedSeats",
                column: "ReservationId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservedSeats");

            migrationBuilder.DropTable(
                name: "TotalSeats");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ScheduledEvents");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");
        }
    }
}
