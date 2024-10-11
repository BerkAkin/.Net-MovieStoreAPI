using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CustomerMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                   name: "CustomerMovies",
                   columns: table => new
                   {
                       CustomerId = table.Column<int>(nullable: false),
                       MovieId = table.Column<int>(nullable: false)
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_CustomerMovies", x => new { x.CustomerId, x.MovieId });
                       table.ForeignKey(
                           name: "FK_CustomerMovies_Customers_CustomerId",
                           column: x => x.CustomerId,
                           principalTable: "Customers",
                           principalColumn: "Id",
                           onDelete: ReferentialAction.Cascade);
                       table.ForeignKey(
                           name: "FK_CustomerMovies_Movies_MovieId",
                           column: x => x.MovieId,
                           principalTable: "Movies",
                           principalColumn: "Id",
                           onDelete: ReferentialAction.Cascade);
                   });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMovies");
        }
    }
}
