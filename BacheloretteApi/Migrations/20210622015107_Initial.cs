using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BacheloretteApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bachelorettes",
                columns: table => new
                {
                    BacheloretteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Hometown = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bachelorettes", x => x.BacheloretteId);
                });

            migrationBuilder.CreateTable(
                name: "Contestants",
                columns: table => new
                {
                    ContestantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Hometown = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsEliminated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WeeksIn = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    BacheloretteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestants", x => x.ContestantId);
                    table.ForeignKey(
                        name: "FK_Contestants_Bachelorettes_BacheloretteId",
                        column: x => x.BacheloretteId,
                        principalTable: "Bachelorettes",
                        principalColumn: "BacheloretteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_BacheloretteId",
                table: "Contestants",
                column: "BacheloretteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contestants");

            migrationBuilder.DropTable(
                name: "Bachelorettes");
        }
    }
}
