using Microsoft.EntityFrameworkCore.Migrations;

namespace BacheloretteApi.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Bachelorettes_BacheloretteId",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "WeeksIn",
                table: "Contestants");

            migrationBuilder.AlterColumn<int>(
                name: "BacheloretteId",
                table: "Contestants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Bachelorettes",
                columns: new[] { "BacheloretteId", "Age", "Hometown", "Job", "Name", "Season" },
                values: new object[] { 1, 30, "Renton, WA", "Marketing manager", "Katie Thurston", 17 });

            migrationBuilder.InsertData(
                table: "Contestants",
                columns: new[] { "ContestantId", "Age", "BacheloretteId", "Hometown", "IsEliminated", "Job", "Name", "Season" },
                values: new object[] { 1, 27, 1, "Edison, NJ", false, "Marketing Sales Representative", "Greg", 17 });

            migrationBuilder.InsertData(
                table: "Contestants",
                columns: new[] { "ContestantId", "Age", "BacheloretteId", "Hometown", "IsEliminated", "Job", "Name", "Season" },
                values: new object[] { 2, 26, 1, "San Diego, CA", false, "Insurance Agent", "Aaron", 17 });

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Bachelorettes_BacheloretteId",
                table: "Contestants",
                column: "BacheloretteId",
                principalTable: "Bachelorettes",
                principalColumn: "BacheloretteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Bachelorettes_BacheloretteId",
                table: "Contestants");

            migrationBuilder.DeleteData(
                table: "Contestants",
                keyColumn: "ContestantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contestants",
                keyColumn: "ContestantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bachelorettes",
                keyColumn: "BacheloretteId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "BacheloretteId",
                table: "Contestants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WeeksIn",
                table: "Contestants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Bachelorettes_BacheloretteId",
                table: "Contestants",
                column: "BacheloretteId",
                principalTable: "Bachelorettes",
                principalColumn: "BacheloretteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
