using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM_Project.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Grade", "ServiceName", "ServiceType", "Subject" },
                values: new object[] { 1, "test", "Activity", "English" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Grade", "ServiceName", "ServiceType", "Subject" },
                values: new object[] { 10, "Example Service", "Type1", "Subject1" });
        }
    }
}
