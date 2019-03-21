using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GdmStore.Migrations
{
    public partial class changetypesvariablesinmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "ProductTypes",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductParameters",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ParameterId",
                table: "ProductParameters",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ProductParameterId",
                table: "ProductParameters",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Parameters",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ParameterId",
                table: "Parameters",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "NameType" },
                values: new object[] { 1, "Шток хромированный" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "NameType" },
                values: new object[] { 2, "Труба хонингованная" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "ParameterId", "Name", "ProductTypeId" },
                values: new object[,]
                {
                    { 2, "Тип штока", 1 },
                    { 3, "Марка стали", 1 },
                    { 4, "Диаметр", 1 },
                    { 1, "Тип трубы", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Amount", "Name", "Number", "PrimeCostEUR", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, 6.04, "Шток хромированный", "50-E-1", 34.65, 1 },
                    { 2, 6.84, "Шток хромированный", "50-V2-1", 39.87, 1 },
                    { 3, 7.24, "Труба хонингованная", "80*95-E-4", 25.85, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductParameters",
                columns: new[] { "ProductParameterId", "ParameterId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 3, 3, 1, "CK45" },
                    { 4, 4, 1, "40" },
                    { 1, 2, 2, "H9" },
                    { 5, 4, 2, "50" },
                    { 2, 1, 1, "Обычный" },
                    { 6, 4, 3, "80*95" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductParameters",
                keyColumn: "ProductParameterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "ParameterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 2);

            migrationBuilder.AlterColumn<long>(
                name: "ProductTypeId",
                table: "ProductTypes",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ProductTypeId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductParameters",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ParameterId",
                table: "ProductParameters",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ProductParameterId",
                table: "ProductParameters",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ProductTypeId",
                table: "Parameters",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ParameterId",
                table: "Parameters",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                columns: new[] { "ProductId", "Amount", "Name", "Number", "PrimeCostEUR", "ProductTypeId" },
                values: new object[,]
                {
                    { 1L, 6.04, "Шток хромированный", "50-E-1", 34.65, 1L },
                    { 2L, 6.84, "Шток хромированный", "50-V2-1", 39.87, 1L },
                    { 3L, 7.24, "Труба хонингованная", "80*95-E-4", 25.85, 2L }
                });

            migrationBuilder.InsertData(
                table: "ProductParameters",
                columns: new[] { "ProductParameterId", "ParameterId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 3L, 3L, 1L, "CK45" },
                    { 4L, 4L, 1L, "40" },
                    { 1L, 2L, 2L, "H9" },
                    { 5L, 4L, 2L, "50" },
                    { 2L, 1L, 1L, "Обычный" },
                    { 6L, 4L, 3L, "80*95" }
                });
        }
    }
}
