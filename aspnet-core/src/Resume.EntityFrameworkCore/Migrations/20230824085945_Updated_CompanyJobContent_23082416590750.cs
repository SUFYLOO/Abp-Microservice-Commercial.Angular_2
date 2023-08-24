using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCompanyJobContent23082416590750 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkDifferentPlaces",
                table: "AppCompanyJobContents");

            migrationBuilder.DropColumn(
                name: "WorkHour",
                table: "AppCompanyJobContents");

            migrationBuilder.DropColumn(
                name: "WorkIdentityCode",
                table: "AppCompanyJobContents");

            migrationBuilder.RenameColumn(
                name: "WorkRemote",
                table: "AppCompanyJobContents",
                newName: "WorkHoursCustom");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPlace",
                table: "AppCompanyJobContents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkHours",
                table: "AppCompanyJobContents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTypeContent",
                table: "AppCompanyJobContents",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobType",
                table: "AppCompanyJobContents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisabilityCategory",
                table: "AppCompanyJobContents",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessTrip",
                table: "AppCompanyJobContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dispatched",
                table: "AppCompanyJobContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WorkIdentity",
                table: "AppCompanyJobContents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkRemoteDescript",
                table: "AppCompanyJobContents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessTrip",
                table: "AppCompanyJobContents");

            migrationBuilder.DropColumn(
                name: "Dispatched",
                table: "AppCompanyJobContents");

            migrationBuilder.DropColumn(
                name: "WorkIdentity",
                table: "AppCompanyJobContents");

            migrationBuilder.DropColumn(
                name: "WorkRemoteDescript",
                table: "AppCompanyJobContents");

            migrationBuilder.RenameColumn(
                name: "WorkHoursCustom",
                table: "AppCompanyJobContents",
                newName: "WorkRemote");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPlace",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkHours",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTypeContent",
                table: "AppCompanyJobContents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobType",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisabilityCategory",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkDifferentPlaces",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkHour",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkIdentityCode",
                table: "AppCompanyJobContents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
