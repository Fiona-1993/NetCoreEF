using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMigration.Migrations
{
    public partial class employeedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "CompanyName", "Email", "Name", "Salary", "age" },
                values: new object[] { 1, "上海", "腾讯", "Robin@tengxun.com", "Robin", 300000f, 22 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "CompanyName", "Email", "Name", "Salary", "age" },
                values: new object[] { 2, "北京", "头条", "Susan@toutiao.com", "Susan", 250000f, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);
        }
    }
}
