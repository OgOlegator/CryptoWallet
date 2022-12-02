using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.WalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTransactionModelInDbV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "History",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "History");
        }
    }
}
