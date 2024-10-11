﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CustomerGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "CustomerGenres",
                    columns: table => new
                    {
                        CustomerId = table.Column<int>(nullable: false),
                        GenreId = table.Column<int>(nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_CustomerGenres", x => new { x.CustomerId, x.GenreId });
                        table.ForeignKey(
                            name: "FK_CustomerGenres_Customers_CustomerId",
                            column: x => x.CustomerId,
                            principalTable: "Customers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_CustomerGenres_Genres_GenreId",
                            column: x => x.GenreId,
                            principalTable: "Genres",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGenres");
        }
    }
}
