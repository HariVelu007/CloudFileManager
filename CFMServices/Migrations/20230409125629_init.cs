using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFMServices.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMail = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HashSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NoOfFailedAttempts = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    Profile = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    FileSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFiles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFileAccess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFileID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFileAccess", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFileAccess_UserFiles_UserFileID",
                        column: x => x.UserFileID,
                        principalTable: "UserFiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFileAccess_UserFileID",
                table: "UserFileAccess",
                column: "UserFileID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles",
                column: "UserID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFileAccess");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
