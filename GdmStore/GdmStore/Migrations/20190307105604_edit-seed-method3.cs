using Microsoft.EntityFrameworkCore.Migrations;

namespace GdmStore.Migrations
{
    public partial class editseedmethod3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductParameters",
                columns: new[] { "ProductParameterId", "ParameterId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1L, 2L, 2L, "H9" },
                    { 2L, 1L, 1L, "Обычный" },
                    { 3L, 3L, 1L, "CK45" },
                    { 4L, 4L, 1L, "40" },
                    { 5L, 4L, 2L, "50" },
                    { 6L, 4L, 3L, "80*95" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 6L);
        }
    }
}
