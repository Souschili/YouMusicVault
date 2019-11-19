using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAPI.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Nickname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<string>(maxLength: 30, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastVisit = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserJwtdb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJwtdb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJwtdb_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "refreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefreshToken = table.Column<string>(nullable: true),
                    IsCalled = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CallTime = table.Column<DateTime>(nullable: true),
                    JwtID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshTokens_UserJwtdb_JwtID",
                        column: x => x.JwtID,
                        principalTable: "UserJwtdb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_JwtID",
                table: "refreshTokens",
                column: "JwtID");

            migrationBuilder.CreateIndex(
                name: "IX_UserJwtdb_UserID",
                table: "UserJwtdb",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "UserJwtdb");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
