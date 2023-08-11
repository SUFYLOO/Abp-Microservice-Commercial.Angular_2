using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCompanyJobCondition23081111394859 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyJobCode",
                table: "AppCompanyJobConditions");

            migrationBuilder.DropColumn(
                name: "CompanyMainCode",
                table: "AppCompanyJobConditions");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyJobId",
                table: "AppCompanyJobConditions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyMainId",
                table: "AppCompanyJobConditions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyJobId",
                table: "AppCompanyJobConditions");

            migrationBuilder.DropColumn(
                name: "CompanyMainId",
                table: "AppCompanyJobConditions");

            migrationBuilder.AddColumn<string>(
                name: "CompanyJobCode",
                table: "AppCompanyJobConditions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyMainCode",
                table: "AppCompanyJobConditions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
