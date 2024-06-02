using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM_Project.Migrations
{
    /// <inheritdoc />
    public partial class chapters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Chapter",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lesson",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Lesson",
                table: "Services");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "FilePath", "Grade", "ServiceName", "ServiceType", "Subject" },
                values: new object[] { 1, "/path/to/file", 1, "test", "Activity", "English" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "College", "Department", "Educational_level", "Email", "Government", "Major", "Name", "Password", "Specialization_subject", "Type", "Workplace" },
                values: new object[] { 1, null, null, null, null, "admin@admin", null, null, "Admin", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", null, "admin", null });
        }
    }
}
