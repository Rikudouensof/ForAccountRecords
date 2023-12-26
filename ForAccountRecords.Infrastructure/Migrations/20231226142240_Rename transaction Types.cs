using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenametransactionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionClassifications_TransactionEntries_TransactionTypeId",
                table: "TransactionClassifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionEntries",
                table: "TransactionEntries");

            migrationBuilder.RenameTable(
                name: "TransactionEntries",
                newName: "TransactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionClassifications_TransactionTypes_TransactionTypeId",
                table: "TransactionClassifications",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionClassifications_TransactionTypes_TransactionTypeId",
                table: "TransactionClassifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionEntries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionEntries",
                table: "TransactionEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionClassifications_TransactionEntries_TransactionTypeId",
                table: "TransactionClassifications",
                column: "TransactionTypeId",
                principalTable: "TransactionEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
