using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace blogUp.Migrations
{
    public partial class BlogDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    author = table.Column<string>(nullable: true),
                    avatar = table.Column<byte[]>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    uri = table.Column<string>(nullable: true),
                    createdAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
