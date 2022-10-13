using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpOrgStructManagApp.Migrations
{
    public partial class addOrganizationUnitIdToEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizationUnitId",
                table: "Employees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationUnitId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Employees");
        }
    }
}
