using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAPI.Migrations
{
    public partial class Full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshToken_UserJwtdb_UserTokenId",
                table: "UserRefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRefreshToken",
                table: "UserRefreshToken");

            migrationBuilder.RenameTable(
                name: "UserRefreshToken",
                newName: "refreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_UserRefreshToken_UserTokenId",
                table: "refreshTokens",
                newName: "IX_refreshTokens_UserTokenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokens_UserJwtdb_UserTokenId",
                table: "refreshTokens",
                column: "UserTokenId",
                principalTable: "UserJwtdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokens_UserJwtdb_UserTokenId",
                table: "refreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens");

            migrationBuilder.RenameTable(
                name: "refreshTokens",
                newName: "UserRefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_refreshTokens_UserTokenId",
                table: "UserRefreshToken",
                newName: "IX_UserRefreshToken_UserTokenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRefreshToken",
                table: "UserRefreshToken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshToken_UserJwtdb_UserTokenId",
                table: "UserRefreshToken",
                column: "UserTokenId",
                principalTable: "UserJwtdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
