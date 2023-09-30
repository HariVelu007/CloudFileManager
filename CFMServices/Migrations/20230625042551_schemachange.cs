using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFMServices.Migrations
{
    public partial class schemachange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles",
                column: "UserID",
                unique: true);
        }
    }
}
