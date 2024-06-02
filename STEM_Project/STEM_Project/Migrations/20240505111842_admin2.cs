using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM_Project.Migrations
{
    /// <inheritdoc />
    public partial class admin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin123");
        }
    }
}
