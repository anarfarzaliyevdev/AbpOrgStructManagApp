using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpOrgStructManagApp.Migrations
{
    public partial class removeDependIdFromEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DependId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DependId",
                table: "Employees",
                type: "int",
                nullable: true);
        }
    }
}
