using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCompanyJobDisabilityCategory23082510221532 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisabilityLevelCode",
                table: "AppCompanyJobDisabilityCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisabilityLevelCode",
                table: "AppCompanyJobDisabilityCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
