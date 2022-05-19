using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDemo3.Migrations
{
    public partial class ipl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    MatchesWin = table.Column<int>(type: "int", nullable: false),
                    MatchesLoss = table.Column<int>(type: "int", nullable: false),
                    NetRunrate = table.Column<int>(type: "int", nullable: false),
                    TeamPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPLs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPLs");
        }
    }
}
