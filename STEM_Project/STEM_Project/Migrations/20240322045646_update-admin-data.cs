using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateadmindata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 0,
                columns: new[] { "Age", "College", "Department", "Division", "Email", "Government", "Name", "Password", "Specialization_subject", "Workplace" },
                values: new object[] { 21, null, null, null, "admin@admin.com", null, "Admin", "admin", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 0,
                columns: new[] { "Age", "College", "Department", "Division", "Email", "Government", "Name", "Password", "Specialization_subject", "Workplace" },
                values: new object[] { 30, "Admin College", "Admin Department", "Admin Division", "admin@example.com", "Admin Government", "Admin Name", "adminpassword", "Admin Specialization", "Admin Workplace" });
        }
    }
}
