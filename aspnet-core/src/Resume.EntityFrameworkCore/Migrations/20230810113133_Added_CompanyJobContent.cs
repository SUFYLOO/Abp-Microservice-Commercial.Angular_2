using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyJobContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCompanyJobContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyMainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PeopleRequiredNumber = table.Column<int>(type: "int", nullable: false),
                    PeopleRequiredNumberUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    JobTypeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryPayTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryMin = table.Column<int>(type: "int", nullable: false),
                    SalaryMax = table.Column<int>(type: "int", nullable: false),
                    SalaryUp = table.Column<bool>(type: "bit", nullable: false),
                    WorkPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkHours = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkHour = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkShift = table.Column<bool>(type: "bit", nullable: false),
                    WorkRemoteAllow = table.Column<bool>(type: "bit", nullable: false),
                    WorkRemoteTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkRemote = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkDifferentPlaces = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HolidaySystemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkDayCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkIdentityCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DisabilityCategory = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExtendedInformation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCompanyJobContents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCompanyJobContents");
        }
    }
}
