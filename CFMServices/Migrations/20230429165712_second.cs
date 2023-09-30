using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFMServices.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserFileAccess",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserFileAccess",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserFileAccess");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserFileAccess");
        }
    }
}
