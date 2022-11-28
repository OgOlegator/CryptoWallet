using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.WalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChengeModelTransactionHistoryInDbV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "History",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                table: "History",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "History",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                table: "History",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarchar(30)");
        }
    }
}
