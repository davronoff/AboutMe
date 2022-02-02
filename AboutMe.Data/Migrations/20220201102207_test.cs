using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboutMe.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partifolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    partifolioName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    pratifolioDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    imageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partifolios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partifolios");
        }
    }
}
