using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration0 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
