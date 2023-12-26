using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makeentrytypenondependent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryTypes_SubTransactionClassifications_SubTransactionClassificationId",
                table: "EntryTypes");

            migrationBuilder.DropIndex(
                name: "IX_EntryTypes_SubTransactionClassificationId",
                table: "EntryTypes");

            migrationBuilder.DropColumn(
                name: "SubTransactionClassificationId",
                table: "EntryTypes");

            migrationBuilder.AddColumn<int>(
                name: "SubTransactionClassificationId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_SubTransactionClassificationId",
                table: "Entries",
                column: "SubTransactionClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_SubTransactionClassifications_SubTransactionClassificationId",
                table: "Entries",
                column: "SubTransactionClassificationId",
                principalTable: "SubTransactionClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_SubTransactionClassifications_SubTransactionClassificationId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_SubTransactionClassificationId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "SubTransactionClassificationId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "SubTransactionClassificationId",
                table: "EntryTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntryTypes_SubTransactionClassificationId",
                table: "EntryTypes",
                column: "SubTransactionClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryTypes_SubTransactionClassifications_SubTransactionClassificationId",
                table: "EntryTypes",
                column: "SubTransactionClassificationId",
                principalTable: "SubTransactionClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
