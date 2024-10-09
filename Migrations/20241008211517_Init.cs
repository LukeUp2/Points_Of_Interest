using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Points_Of_Interest.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Points_Of_Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POI_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X_Coord = table.Column<int>(type: "int", nullable: false),
                    Y_Coord = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points_Of_Interests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points_Of_Interests");
        }
    }
}
