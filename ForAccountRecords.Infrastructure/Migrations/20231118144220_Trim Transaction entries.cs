using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TrimTransactionentries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cashflow",
                table: "TransactionEntries");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "TransactionEntries");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "TransactionEntries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cashflow",
                table: "TransactionEntries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "TransactionEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "TransactionEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
