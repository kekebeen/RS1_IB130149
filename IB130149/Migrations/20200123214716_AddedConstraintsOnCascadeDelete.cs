using Microsoft.EntityFrameworkCore.Migrations;

namespace IB130149.Migrations
{
    public partial class AddedConstraintsOnCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTicket_User_CustomerId",
                table: "ServiceTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTicket_Employee_EmployeeId",
                table: "ServiceTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTicket_ServiceRequest_ServiceRequestId",
                table: "ServiceTicket");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTicket_User_CustomerId",
                table: "ServiceTicket",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTicket_Employee_EmployeeId",
                table: "ServiceTicket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTicket_ServiceRequest_ServiceRequestId",
                table: "ServiceTicket",
                column: "ServiceRequestId",
                principalTable: "ServiceRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTicket_User_CustomerId",
                table: "ServiceTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTicket_Employee_EmployeeId",
                table: "ServiceTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTicket_ServiceRequest_ServiceRequestId",
                table: "ServiceTicket");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTicket_User_CustomerId",
                table: "ServiceTicket",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTicket_Employee_EmployeeId",
                table: "ServiceTicket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTicket_ServiceRequest_ServiceRequestId",
                table: "ServiceTicket",
                column: "ServiceRequestId",
                principalTable: "ServiceRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
