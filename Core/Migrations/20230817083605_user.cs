using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPwdChg",
                table: "tblUser",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "tblRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "tblRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "tblRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "tblRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "tblRole",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "tblRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "tblRole",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPwdChg",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblRole");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "tblRole");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "tblRole");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "tblRole");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "tblRole");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tblRole");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "tblRole");
        }
    }
}
