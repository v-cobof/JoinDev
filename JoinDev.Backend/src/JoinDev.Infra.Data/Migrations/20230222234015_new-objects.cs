using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinDev.Infra.Data.Migrations
{
    public partial class newobjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThemeCategory",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "LinkSource",
                table: "Links");

            migrationBuilder.AddColumn<Guid>(
                name: "ThemeCategoryId",
                table: "Themes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LinkSourceId",
                table: "Links",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "LinkSource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemeCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ThemeCategoryId",
                table: "Themes",
                column: "ThemeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinkSourceId",
                table: "Links",
                column: "LinkSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_LinkSource_LinkSourceId",
                table: "Links",
                column: "LinkSourceId",
                principalTable: "LinkSource",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_ThemeCategory_ThemeCategoryId",
                table: "Themes",
                column: "ThemeCategoryId",
                principalTable: "ThemeCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_LinkSource_LinkSourceId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_ThemeCategory_ThemeCategoryId",
                table: "Themes");

            migrationBuilder.DropTable(
                name: "LinkSource");

            migrationBuilder.DropTable(
                name: "ThemeCategory");

            migrationBuilder.DropIndex(
                name: "IX_Themes_ThemeCategoryId",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Links_LinkSourceId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "ThemeCategoryId",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "LinkSourceId",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "ThemeCategory",
                table: "Themes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LinkSource",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
