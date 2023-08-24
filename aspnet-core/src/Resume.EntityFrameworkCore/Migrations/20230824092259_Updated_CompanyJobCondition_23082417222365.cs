using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCompanyJobCondition23082417222365 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageCategory",
                table: "AppCompanyJobConditions");

            migrationBuilder.RenameColumn(
                name: "ComputerExpertise",
                table: "AppCompanyJobConditions",
                newName: "WorkSkills");

            migrationBuilder.AlterColumn<string>(
                name: "MajorDepartmentCategory",
                table: "AppCompanyJobConditions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EtcCondition",
                table: "AppCompanyJobConditions",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "AppCompanyJobConditions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DrvingLicense",
                table: "AppCompanyJobConditions",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComputerExpertiseEtc",
                table: "AppCompanyJobConditions",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCondition",
                table: "AppCompanyJobConditions",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalLicenseEtc",
                table: "AppCompanyJobConditions",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkSkillsEtc",
                table: "AppCompanyJobConditions",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerExpertiseEtc",
                table: "AppCompanyJobConditions");

            migrationBuilder.DropColumn(
                name: "LanguageCondition",
                table: "AppCompanyJobConditions");

            migrationBuilder.DropColumn(
                name: "ProfessionalLicenseEtc",
                table: "AppCompanyJobConditions");

            migrationBuilder.DropColumn(
                name: "WorkSkillsEtc",
                table: "AppCompanyJobConditions");

            migrationBuilder.RenameColumn(
                name: "WorkSkills",
                table: "AppCompanyJobConditions",
                newName: "ComputerExpertise");

            migrationBuilder.AlterColumn<string>(
                name: "MajorDepartmentCategory",
                table: "AppCompanyJobConditions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EtcCondition",
                table: "AppCompanyJobConditions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "AppCompanyJobConditions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DrvingLicense",
                table: "AppCompanyJobConditions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCategory",
                table: "AppCompanyJobConditions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
