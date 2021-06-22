using Microsoft.EntityFrameworkCore.Migrations;

namespace BacheloretteApi.Migrations
{
    public partial class NoVirtualProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Bachelorettes_BacheloretteId",
                table: "Contestants");

            migrationBuilder.DropIndex(
                name: "IX_Contestants_BacheloretteId",
                table: "Contestants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contestants_BacheloretteId",
                table: "Contestants",
                column: "BacheloretteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Bachelorettes_BacheloretteId",
                table: "Contestants",
                column: "BacheloretteId",
                principalTable: "Bachelorettes",
                principalColumn: "BacheloretteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
