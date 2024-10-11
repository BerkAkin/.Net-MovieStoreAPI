using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Directors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Directors",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"), // Otomatik artan anahtar
                Name = table.Column<string>(nullable: false, maxLength: 50),
                Surname = table.Column<string>(nullable: false, maxLength: 50),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Directors", x => x.Id);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
