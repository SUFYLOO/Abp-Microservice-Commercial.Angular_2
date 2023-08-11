﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class AddedResumeLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppResumeLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResumeMainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCategoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LevelSayCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LevelListenCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LevelReadCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LevelWriteCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_AppResumeLanguages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppResumeLanguages");
        }
    }
}