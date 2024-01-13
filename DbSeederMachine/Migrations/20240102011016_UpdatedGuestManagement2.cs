using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbSeederMachine.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedGuestManagement2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestManagements_Employees_EmployeeID",
                table: "GuestManagements");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "GuestManagements",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestManagements_EmployeeID",
                table: "GuestManagements",
                newName: "IX_GuestManagements_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "GuestManagements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestManagements_Employees_EmployeeId",
                table: "GuestManagements",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestManagements_Employees_EmployeeId",
                table: "GuestManagements");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "GuestManagements",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_GuestManagements_EmployeeId",
                table: "GuestManagements",
                newName: "IX_GuestManagements_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "GuestManagements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestManagements_Employees_EmployeeID",
                table: "GuestManagements",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
