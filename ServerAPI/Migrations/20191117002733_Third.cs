using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAPI.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTokens_User_UserID",
                table: "userTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userTokens",
                table: "userTokens");

            migrationBuilder.RenameTable(
                name: "userTokens",
                newName: "UserJwtdb");

            migrationBuilder.RenameIndex(
                name: "IX_userTokens_UserID",
                table: "UserJwtdb",
                newName: "IX_UserJwtdb_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserJwtdb",
                table: "UserJwtdb",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefreshToken = table.Column<string>(nullable: true),
                    IsCalled = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CallTime = table.Column<DateTime>(nullable: false),
                    UserTokenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_UserJwtdb_UserTokenId",
                        column: x => x.UserTokenId,
                        principalTable: "UserJwtdb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_UserTokenId",
                table: "UserRefreshToken",
                column: "UserTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserJwtdb_User_UserID",
                table: "UserJwtdb",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserJwtdb_User_UserID",
                table: "UserJwtdb");

            migrationBuilder.DropTable(
                name: "UserRefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserJwtdb",
                table: "UserJwtdb");

            migrationBuilder.RenameTable(
                name: "UserJwtdb",
                newName: "userTokens");

            migrationBuilder.RenameIndex(
                name: "IX_UserJwtdb_UserID",
                table: "userTokens",
                newName: "IX_userTokens_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTokens",
                table: "userTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userTokens_User_UserID",
                table: "userTokens",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
