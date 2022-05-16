using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dbcontroller.Migrations
{
    public partial class author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    authorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isalive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.authorid);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    bookid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pages = table.Column<int>(type: "int", nullable: false),
                    wordcount = table.Column<double>(type: "float", nullable: false),
                    binding = table.Column<bool>(type: "bit", nullable: false),
                    releaseyear = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.bookid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "book");
        }
    }
}
