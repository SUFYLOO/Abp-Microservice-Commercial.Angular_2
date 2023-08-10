using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyInvitations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCompanyInvitationss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyMainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpenAllJob = table.Column<bool>(type: "bit", nullable: false),
                    UserMainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserMainName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserMainLoginMobilePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserMainLoginEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserMainLoginIdentityNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SendTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SendStatusCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResumeFlowStageCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserCompanyBindId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResumeSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AppCompanyInvitationss", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCompanyInvitationss");
        }
    }
}
