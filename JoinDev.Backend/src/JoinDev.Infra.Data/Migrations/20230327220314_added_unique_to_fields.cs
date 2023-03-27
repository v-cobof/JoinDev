using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinDev.Infra.Data.Migrations
{
    public partial class added_unique_to_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Themes_Name",
                table: "Themes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeCategory_Name",
                table: "ThemeCategory",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LinkSource_Name",
                table: "LinkSource",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Themes_Name",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_ThemeCategory_Name",
                table: "ThemeCategory");

            migrationBuilder.DropIndex(
                name: "IX_LinkSource_Name",
                table: "LinkSource");
        }
    }
}
