using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAPI.Migrations
{
    public partial class prefinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokens_UserJwtdb_UserTokenId",
                table: "refreshTokens");

            migrationBuilder.RenameColumn(
                name: "UserTokenId",
                table: "refreshTokens",
                newName: "JwtID");

            migrationBuilder.RenameIndex(
                name: "IX_refreshTokens_UserTokenId",
                table: "refreshTokens",
                newName: "IX_refreshTokens_JwtID");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokens_UserJwtdb_JwtID",
                table: "refreshTokens",
                column: "JwtID",
                principalTable: "UserJwtdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokens_UserJwtdb_JwtID",
                table: "refreshTokens");

            migrationBuilder.RenameColumn(
                name: "JwtID",
                table: "refreshTokens",
                newName: "UserTokenId");

            migrationBuilder.RenameIndex(
                name: "IX_refreshTokens_JwtID",
                table: "refreshTokens",
                newName: "IX_refreshTokens_UserTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokens_UserJwtdb_UserTokenId",
                table: "refreshTokens",
                column: "UserTokenId",
                principalTable: "UserJwtdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
