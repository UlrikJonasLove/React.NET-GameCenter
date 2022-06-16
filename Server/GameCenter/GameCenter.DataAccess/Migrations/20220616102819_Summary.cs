using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCenter.DataAccess.Migrations
{
    public partial class Summary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Games");
        }
    }
}
