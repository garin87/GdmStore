using Microsoft.EntityFrameworkCore.Migrations;

namespace GdmStore.Migrations
{
    public partial class editseedmethod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "NameType" },
                values: new object[] { 1L, "Шток хромированный" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "NameType" },
                values: new object[] { 2L, "Труба хонингованная" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "ParameterId", "Name", "ProductTypeId" },
                values: new object[,]
                {
                    { 2L, "Тип штока", 1L },
                    { 3L, "Марка стали", 1L },
                    { 4L, "Диаметр", 1L },
                    { 1L, "Тип трубы", 2L }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Amount", "Name", "Number", "PrimeCostEUR", "ProductParameterId", "ProductTypeId" },
                values: new object[,]
                {
                    { 1L, 6.04, "Шток хромированный", "50-E-1", 34.65, 0L, 1L },
                    { 2L, 6.84, "Шток хромированный", "50-V2-1", 39.87, 0L, 1L },
                    { 3L, 7.24, "Труба хонингованная", "80*95-E-4", 25.85, 0L, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 2L);
        }
    }
}
