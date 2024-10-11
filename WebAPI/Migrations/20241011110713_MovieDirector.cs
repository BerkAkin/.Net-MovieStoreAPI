using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class MovieDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "MovieDirectors",
                    columns: table => new
                    {
                        MovieId = table.Column<int>(nullable: false),
                        DirectorId = table.Column<int>(nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_MovieDirectors", x => new { x.MovieId, x.DirectorId });
                        table.ForeignKey(
                            name: "FK_MovieDirectors_Movies_MovieId",
                            column: x => x.MovieId,
                            principalTable: "Movies",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_MovieDirectors_Directors_DirectorId",
                            column: x => x.DirectorId,
                            principalTable: "Directors",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDirectors");
        }
    }
}
