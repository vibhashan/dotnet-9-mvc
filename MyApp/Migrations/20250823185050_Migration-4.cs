using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
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

            migrationBuilder.CreateTable(
                name: "ITEM_CLIENT_TAB",
                columns: table => new
                {
                    ItemId = table.Column<decimal>(type: "NUMBER(38,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "NUMBER(38,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_CLIENT_TAB", x => new { x.ItemId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ITEM_CLIENT_TAB_CLIENT_TAB_ClientId",
                        column: x => x.ClientId,
                        principalTable: "CLIENT_TAB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITEM_CLIENT_TAB_ITEM_TAB_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ITEM_TAB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_CLIENT_TAB_ClientId",
                table: "ITEM_CLIENT_TAB",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITEM_CLIENT_TAB");

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
