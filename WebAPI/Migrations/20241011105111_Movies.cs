using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Movies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                   name: "Movies",
                   columns: table => new
                   {
                       Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"), // Otomatik artan anahtar
                       Name = table.Column<string>(nullable: false, maxLength: 50),
                       Year = table.Column<DateTime>(nullable: false),
                       Price = table.Column<int>(nullable: false)
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_Movies", x => x.Id);
                   });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
