using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.WalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChengeModelTransactionHistoryInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coin",
                table: "History",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coin",
                table: "History");
        }
    }
}
