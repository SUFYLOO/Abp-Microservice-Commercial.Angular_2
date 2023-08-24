using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedResumeExperiences23082416022012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkPlaceCode",
                table: "AppResumeExperiencess",
                newName: "WorkPlace");

            migrationBuilder.RenameColumn(
                name: "IndustryCategoryCode",
                table: "AppResumeExperiencess",
                newName: "IndustryCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkPlace",
                table: "AppResumeExperiencess",
                newName: "WorkPlaceCode");

            migrationBuilder.RenameColumn(
                name: "IndustryCategory",
                table: "AppResumeExperiencess",
                newName: "IndustryCategoryCode");
        }
    }
}
