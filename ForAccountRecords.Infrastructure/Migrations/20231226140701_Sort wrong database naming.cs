using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sortwrongdatabasenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryTypes_TransactionClassifications_SubTransactionClassificationId",
                table: "EntryTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionClassifications_TransactionClassification_TransactionClassificationId",
                table: "TransactionClassifications");

            migrationBuilder.DropTable(
                name: "TransactionClassification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "TransactionEntries");

            migrationBuilder.RenameColumn(
                name: "TransactionClassificationId",
                table: "TransactionClassifications",
                newName: "TransactionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionClassifications_TransactionClassificationId",
                table: "TransactionClassifications",
                newName: "IX_TransactionClassifications_TransactionTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionEntries",
                table: "TransactionEntries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SubTransactionClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTransactionClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTransactionClassifications_TransactionClassifications_TransactionClassificationId",
                        column: x => x.TransactionClassificationId,
                        principalTable: "TransactionClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactionClassifications_TransactionClassificationId",
                table: "SubTransactionClassifications",
                column: "TransactionClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryTypes_SubTransactionClassifications_SubTransactionClassificationId",
                table: "EntryTypes",
                column: "SubTransactionClassificationId",
                principalTable: "SubTransactionClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionClassifications_TransactionEntries_TransactionTypeId",
                table: "TransactionClassifications",
                column: "TransactionTypeId",
                principalTable: "TransactionEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryTypes_SubTransactionClassifications_SubTransactionClassificationId",
                table: "EntryTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionClassifications_TransactionEntries_TransactionTypeId",
                table: "TransactionClassifications");

            migrationBuilder.DropTable(
                name: "SubTransactionClassifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionEntries",
                table: "TransactionEntries");

            migrationBuilder.RenameTable(
                name: "TransactionEntries",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "TransactionClassifications",
                newName: "TransactionClassificationId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionClassifications_TransactionTypeId",
                table: "TransactionClassifications",
                newName: "IX_TransactionClassifications_TransactionClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TransactionClassification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionClassification_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionClassification_TransactionTypeId",
                table: "TransactionClassification",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryTypes_TransactionClassifications_SubTransactionClassificationId",
                table: "EntryTypes",
                column: "SubTransactionClassificationId",
                principalTable: "TransactionClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionClassifications_TransactionClassification_TransactionClassificationId",
                table: "TransactionClassifications",
                column: "TransactionClassificationId",
                principalTable: "TransactionClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
