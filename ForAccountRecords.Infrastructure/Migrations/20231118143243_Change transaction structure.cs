using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changetransactionstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntries_EntryTypes_EntryTypeId",
                table: "TransactionEntries");

            migrationBuilder.RenameColumn(
                name: "EntryTypeId",
                table: "TransactionEntries",
                newName: "TransactionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionEntries_EntryTypeId",
                table: "TransactionEntries",
                newName: "IX_TransactionEntries_TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntries_TransactionTypes_TransactionTypeId",
                table: "TransactionEntries",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntries_TransactionTypes_TransactionTypeId",
                table: "TransactionEntries");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "TransactionEntries",
                newName: "EntryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionEntries_TransactionTypeId",
                table: "TransactionEntries",
                newName: "IX_TransactionEntries_EntryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntries_EntryTypes_EntryTypeId",
                table: "TransactionEntries",
                column: "EntryTypeId",
                principalTable: "EntryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
