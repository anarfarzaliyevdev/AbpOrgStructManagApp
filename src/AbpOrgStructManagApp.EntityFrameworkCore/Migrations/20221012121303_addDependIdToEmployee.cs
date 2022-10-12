using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpOrgStructManagApp.Migrations
{
    public partial class addDependIdToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DependId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DependId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employees");
        }
    }
}
