using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "Orders",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                        CustomerId = table.Column<int>(nullable: false),
                        MovieId = table.Column<int>(nullable: false),
                        Price = table.Column<decimal>(nullable: false),
                        PurchaseDate = table.Column<DateTime>(nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Orders", x => x.Id);
                        table.ForeignKey(
                            name: "FK_Order_Customers_CustomerId",
                            column: x => x.CustomerId,
                            principalTable: "Customers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_Order_Movies_FilmId",
                            column: x => x.MovieId,
                            principalTable: "Movies",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
