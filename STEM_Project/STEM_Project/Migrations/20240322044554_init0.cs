using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STEM_Project.Migrations
{
    /// <inheritdoc />
    public partial class init0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Educational_level = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    College = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Division = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Government = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specialization_subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Workplace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07086BC40A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Feedback_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__3214EC079C8FCA39", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Feedback__User_I__3F466844",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "College", "Department", "Division", "Educational_level", "Email", "Government", "Name", "Password", "Specialization_subject", "Type", "Workplace" },
                values: new object[] { 0, 30, "Admin College", "Admin Department", "Admin Division", "University", "admin@example.com", "Admin Government", "Admin Name", "adminpassword", "Admin Specialization", "Admin", "Admin Workplace" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_User_ID",
                table: "Feedback",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534EA26C15C",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
