using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.WalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserBalanceModelInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances");

            migrationBuilder.DropIndex(
                name: "IX_UserBalances_UserId",
                table: "UserBalances");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBalances");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances",
                columns: new[] { "UserId", "Coin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBalances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances",
                columns: new[] { "Id", "UserId", "Coin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBalances_UserId",
                table: "UserBalances",
                column: "UserId");
        }
    }
}
