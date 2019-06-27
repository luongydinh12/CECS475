using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie57.Migrations
{
    public partial class Rating57 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating57",
                table: "Movie57",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating57",
                table: "Movie57");
        }
    }
}
