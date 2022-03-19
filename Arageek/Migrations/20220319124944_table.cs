using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arageek.Migrations
{
    public partial class table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articals_humens_autherId",
                table: "articals");

            migrationBuilder.DropForeignKey(
                name: "FK_humens_userRoles_UserRoleId",
                table: "humens");

            migrationBuilder.DropForeignKey(
                name: "FK_mainCategoreys_articals_articalId",
                table: "mainCategoreys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_humens",
                table: "humens");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "humens");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "humens");

            migrationBuilder.RenameTable(
                name: "humens",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "articalId",
                table: "mainCategoreys",
                newName: "ArticalId");

            migrationBuilder.RenameIndex(
                name: "IX_mainCategoreys_articalId",
                table: "mainCategoreys",
                newName: "IX_mainCategoreys_ArticalId");

            migrationBuilder.RenameColumn(
                name: "autherId",
                table: "articals",
                newName: "AutherId");

            migrationBuilder.RenameIndex(
                name: "IX_articals_autherId",
                table: "articals",
                newName: "IX_articals_AutherId");

            migrationBuilder.RenameIndex(
                name: "IX_humens_UserRoleId",
                table: "users",
                newName: "IX_users_UserRoleId");

            migrationBuilder.AddColumn<int>(
                name: "ArticaleId",
                table: "mainCategoreys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "authers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_articals_authers_AutherId",
                table: "articals",
                column: "AutherId",
                principalTable: "authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mainCategoreys_articals_ArticalId",
                table: "mainCategoreys",
                column: "ArticalId",
                principalTable: "articals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_userRoles_UserRoleId",
                table: "users",
                column: "UserRoleId",
                principalTable: "userRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articals_authers_AutherId",
                table: "articals");

            migrationBuilder.DropForeignKey(
                name: "FK_mainCategoreys_articals_ArticalId",
                table: "mainCategoreys");

            migrationBuilder.DropForeignKey(
                name: "FK_users_userRoles_UserRoleId",
                table: "users");

            migrationBuilder.DropTable(
                name: "authers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ArticaleId",
                table: "mainCategoreys");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "humens");

            migrationBuilder.RenameColumn(
                name: "ArticalId",
                table: "mainCategoreys",
                newName: "articalId");

            migrationBuilder.RenameIndex(
                name: "IX_mainCategoreys_ArticalId",
                table: "mainCategoreys",
                newName: "IX_mainCategoreys_articalId");

            migrationBuilder.RenameColumn(
                name: "AutherId",
                table: "articals",
                newName: "autherId");

            migrationBuilder.RenameIndex(
                name: "IX_articals_AutherId",
                table: "articals",
                newName: "IX_articals_autherId");

            migrationBuilder.RenameIndex(
                name: "IX_users_UserRoleId",
                table: "humens",
                newName: "IX_humens_UserRoleId");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "humens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "humens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "humens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "humens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "humens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_humens",
                table: "humens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_articals_humens_autherId",
                table: "articals",
                column: "autherId",
                principalTable: "humens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_humens_userRoles_UserRoleId",
                table: "humens",
                column: "UserRoleId",
                principalTable: "userRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mainCategoreys_articals_articalId",
                table: "mainCategoreys",
                column: "articalId",
                principalTable: "articals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
