using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updateuserroleid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRolesIdId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRolesIdId",
                table: "Users",
                newName: "UserRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRolesIdId",
                table: "Users",
                newName: "IX_Users_UserRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRolesId",
                table: "Users",
                column: "UserRolesId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRolesId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRolesId",
                table: "Users",
                newName: "UserRolesIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRolesId",
                table: "Users",
                newName: "IX_Users_UserRolesIdId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRolesIdId",
                table: "Users",
                column: "UserRolesIdId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
