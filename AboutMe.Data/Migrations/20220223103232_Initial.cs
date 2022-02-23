using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboutMe.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partifolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    partifolioName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    pratifolioDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    imageFileName = table.Column<string>(type: "text", nullable: true)
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
