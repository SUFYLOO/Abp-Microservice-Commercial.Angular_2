using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedResumeEducations23082415572786 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinorDepartmentCategoryCode",
                table: "AppResumeEducationss",
                newName: "MinorDepartmentCategory");

            migrationBuilder.RenameColumn(
                name: "MajorDepartmentCategoryCode",
                table: "AppResumeEducationss",
                newName: "MajorDepartmentCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinorDepartmentCategory",
                table: "AppResumeEducationss",
                newName: "MinorDepartmentCategoryCode");

            migrationBuilder.RenameColumn(
                name: "MajorDepartmentCategory",
                table: "AppResumeEducationss",
                newName: "MajorDepartmentCategoryCode");
        }
    }
}
