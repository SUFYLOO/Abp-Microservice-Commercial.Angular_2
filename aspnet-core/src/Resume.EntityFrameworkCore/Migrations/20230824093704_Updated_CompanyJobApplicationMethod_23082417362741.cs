using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCompanyJobApplicationMethod23082417362741 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrgDept",
                table: "AppCompanyJobApplicationMethods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrgDept",
                table: "AppCompanyJobApplicationMethods",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
