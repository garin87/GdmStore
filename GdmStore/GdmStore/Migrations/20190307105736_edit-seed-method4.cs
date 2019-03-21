using Microsoft.EntityFrameworkCore.Migrations;

namespace GdmStore.Migrations
{
    public partial class editseedmethod4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductParameterId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductParameterId",
                table: "Products",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
