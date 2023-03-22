using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comp2084_project.Migrations
{
    public partial class removecinemaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CinemaRoomId",
                table: "CinemaRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaRoomId",
                table: "CinemaRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
