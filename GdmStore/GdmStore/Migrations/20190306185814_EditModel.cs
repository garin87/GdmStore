using Microsoft.EntityFrameworkCore.Migrations;

namespace GdmStore.Migrations
{
    public partial class EditModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "SteelGrade",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "TypeTube",
                table: "Parameters");

            migrationBuilder.UpdateData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 1L,
                column: "Value",
                value: "H9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Parameters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Diameter",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SteelGrade",
                table: "Parameters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeTube",
                table: "Parameters",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 1L,
                column: "Value",
                value: "6");
        }
    }
}
