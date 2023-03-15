using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoListApp.DAL.Migrations
{
    public partial class initialcreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "AspNetUsers");
        }
    }
}
