using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comp2084_project.Data.Migrations
{
    public partial class Cinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CinemaRoomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seats_no = table.Column<int>(type: "int", nullable: false),
                    CinemaRoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaRoom_Movie_Id",
                        column: x => x.Id,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaRoom");
        }
    }
}
