using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCompanyMains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Compilation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FaxPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AllowSearch = table.Column<bool>(type: "bit", nullable: false),
                    ExtendedInformation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IndustryCategory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CapitalAmount = table.Column<int>(type: "int", nullable: false),
                    HideCapitalAmount = table.Column<bool>(type: "bit", nullable: false),
                    CompanyScaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HidePrincipal = table.Column<bool>(type: "bit", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyProfile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BusinessPhilosophy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OperatingItems = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WelfareSystem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Matching = table.Column<bool>(type: "bit", nullable: false),
                    ContractPass = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_AppCompanyMains", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCompanyMains");
        }
    }
}
