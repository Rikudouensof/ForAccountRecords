using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addthetransactionpath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionClassification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TransactionClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionClassifications_TransactionClassification_TransactionClassificationId",
                        column: x => x.TransactionClassificationId,
                        principalTable: "TransactionClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTransactionClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryTypes_TransactionClassifications_SubTransactionClassificationId",
                        column: x => x.SubTransactionClassificationId,
                        principalTable: "TransactionClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Units = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefrenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_EntryTypes_EntryTypeId",
                        column: x => x.EntryTypeId,
                        principalTable: "EntryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_EntryTypeId",
                table: "Entries",
                column: "EntryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTypes_SubTransactionClassificationId",
                table: "EntryTypes",
                column: "SubTransactionClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionClassification_TransactionTypeId",
                table: "TransactionClassification",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionClassifications_TransactionClassificationId",
                table: "TransactionClassifications",
                column: "TransactionClassificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "EntryTypes");

            migrationBuilder.DropTable(
                name: "TransactionClassifications");

            migrationBuilder.DropTable(
                name: "TransactionClassification");

            migrationBuilder.DropTable(
                name: "TransactionType");
        }
    }
}
