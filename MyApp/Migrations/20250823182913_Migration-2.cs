using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "ITEM_TAB",
                type: "NUMBER(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.InsertData(
                table: "CATEGORY_TAB",
                columns: new[] { "ID", "NAME" },
                values: new object[] { 3m, "Books" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CATEGORY_TAB",
                keyColumn: "ID",
                keyValue: 3m);

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "ITEM_TAB",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(38,17)");
        }
    }
}
