using Microsoft.EntityFrameworkCore.Migrations;

namespace GdmStore.Migrations
{
    public partial class changeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ProductTypes_ProductTypeId",
                table: "Parameters");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ProductTypes_ProductTypeId",
                table: "Parameters",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ProductTypes_ProductTypeId",
                table: "Parameters");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ProductTypes_ProductTypeId",
                table: "Parameters",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
