﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinDev.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    ThemeCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Image = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: true),
                    PublicDescription = table.Column<string>(type: "varchar(500)", nullable: true),
                    TotalSpots = table.Column<int>(type: "int", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InterestedInProjects",
                columns: table => new
                {
                    InterestedUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsAsInterestedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedInProjects", x => new { x.InterestedUsersId, x.ProjectsAsInterestedId });
                    table.ForeignKey(
                        name: "FK_InterestedInProjects_Projects_ProjectsAsInterestedId",
                        column: x => x.ProjectsAsInterestedId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InterestedInProjects_Users_InterestedUsersId",
                        column: x => x.InterestedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobProjectLevel = table.Column<int>(type: "int", nullable: false),
                    MemberPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobProjects_Projects_Id",
                        column: x => x.Id,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MembersInProjects",
                columns: table => new
                {
                    MemberUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsAsMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersInProjects", x => new { x.MemberUsersId, x.ProjectsAsMemberId });
                    table.ForeignKey(
                        name: "FK_MembersInProjects_Projects_ProjectsAsMemberId",
                        column: x => x.ProjectsAsMemberId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MembersInProjects_Users_MemberUsersId",
                        column: x => x.MemberUsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectsRestrictedInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsRestrictedInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsRestrictedInfo_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTheme",
                columns: table => new
                {
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTheme", x => new { x.ProjectsId, x.ThemesId });
                    table.ForeignKey(
                        name: "FK_ProjectTheme_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTheme_Themes_ThemesId",
                        column: x => x.ThemesId,
                        principalTable: "Themes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudyProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyProjectLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyProjects_Projects_Id",
                        column: x => x.Id,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    LinkSource = table.Column<int>(type: "int", nullable: false),
                    LinkType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => new { x.AggregateId, x.Url });
                    table.ForeignKey(
                        name: "FK_Links_ProjectsRestrictedInfo_AggregateId",
                        column: x => x.AggregateId,
                        principalTable: "ProjectsRestrictedInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Links_Users_AggregateId",
                        column: x => x.AggregateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestedInProjects_ProjectsAsInterestedId",
                table: "InterestedInProjects",
                column: "ProjectsAsInterestedId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersInProjects_ProjectsAsMemberId",
                table: "MembersInProjects",
                column: "ProjectsAsMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsRestrictedInfo_ProjectId",
                table: "ProjectsRestrictedInfo",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTheme_ThemesId",
                table: "ProjectTheme",
                column: "ThemesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestedInProjects");

            migrationBuilder.DropTable(
                name: "JobProjects");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "MembersInProjects");

            migrationBuilder.DropTable(
                name: "ProjectTheme");

            migrationBuilder.DropTable(
                name: "StudyProjects");

            migrationBuilder.DropTable(
                name: "ProjectsRestrictedInfo");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
