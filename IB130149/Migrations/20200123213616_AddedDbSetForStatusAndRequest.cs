using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IB130149.Migrations
{
    public partial class AddedDbSetForStatusAndRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    DeliveryAddress = table.Column<string>(nullable: false),
                    RequestedById = table.Column<int>(nullable: false),
                    Impression = table.Column<string>(nullable: true),
                    IncludeHomeService = table.Column<bool>(nullable: true),
                    IncludeDelivery = table.Column<bool>(nullable: true),
                    IncludeCustomerPickup = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_User_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestDoneDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ServiceRequestId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTicket_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTicket_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTicket_ServiceRequest_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_RequestedById",
                table: "ServiceRequest",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicket_CustomerId",
                table: "ServiceTicket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicket_EmployeeId",
                table: "ServiceTicket",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTicket_ServiceRequestId",
                table: "ServiceTicket",
                column: "ServiceRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceStatus");

            migrationBuilder.DropTable(
                name: "ServiceTicket");

            migrationBuilder.DropTable(
                name: "ServiceRequest");
        }
    }
}
