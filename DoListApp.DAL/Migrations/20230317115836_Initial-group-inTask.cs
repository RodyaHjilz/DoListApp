using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoListApp.DAL.Migrations
{
    public partial class InitialgroupinTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "SimpleTask",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SimpleTask_GroupId",
                table: "SimpleTask",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimpleTask_Group_GroupId",
                table: "SimpleTask",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimpleTask_Group_GroupId",
                table: "SimpleTask");

            migrationBuilder.DropIndex(
                name: "IX_SimpleTask_GroupId",
                table: "SimpleTask");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "SimpleTask");
        }
    }
}
