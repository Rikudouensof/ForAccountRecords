using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpandtheUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondPhoneNumber",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdPhoneNumber",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "XUrl",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "facbookUrl",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "linkedInUrl",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondPhoneNumber",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ThirdPhoneNumber",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "XUrl",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "facbookUrl",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "linkedInUrl",
                table: "Contacts");
        }
    }
}
