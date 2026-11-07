using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademy_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stat1Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Stat1Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stat2Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Stat2Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stat3Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Stat3Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CvUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
