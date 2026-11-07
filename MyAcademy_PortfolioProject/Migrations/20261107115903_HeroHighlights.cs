using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademy_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class HeroHighlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HighlightLabel1",
                table: "HeroSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighlightLabel2",
                table: "HeroSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighlightValue1",
                table: "HeroSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighlightValue2",
                table: "HeroSections",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighlightLabel1",
                table: "HeroSections");

            migrationBuilder.DropColumn(
                name: "HighlightLabel2",
                table: "HeroSections");

            migrationBuilder.DropColumn(
                name: "HighlightValue1",
                table: "HeroSections");

            migrationBuilder.DropColumn(
                name: "HighlightValue2",
                table: "HeroSections");
        }
    }
}
