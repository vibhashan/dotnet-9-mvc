using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_CLIENT_TAB_CLIENT_TAB_ClientId",
                table: "ITEM_CLIENT_TAB");

            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_CLIENT_TAB_ITEM_TAB_ItemId",
                table: "ITEM_CLIENT_TAB");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ITEM_CLIENT_TAB",
                newName: "CLIENT_ID");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ITEM_CLIENT_TAB",
                newName: "ITEM_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ITEM_CLIENT_TAB_ClientId",
                table: "ITEM_CLIENT_TAB",
                newName: "IX_ITEM_CLIENT_TAB_CLIENT_ID");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "ITEM_TAB",
                type: "NUMBER(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_CLIENT_TAB_CLIENT_TAB_CLIENT_ID",
                table: "ITEM_CLIENT_TAB",
                column: "CLIENT_ID",
                principalTable: "CLIENT_TAB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_CLIENT_TAB_ITEM_TAB_ITEM_ID",
                table: "ITEM_CLIENT_TAB",
                column: "ITEM_ID",
                principalTable: "ITEM_TAB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_CLIENT_TAB_CLIENT_TAB_CLIENT_ID",
                table: "ITEM_CLIENT_TAB");

            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_CLIENT_TAB_ITEM_TAB_ITEM_ID",
                table: "ITEM_CLIENT_TAB");

            migrationBuilder.RenameColumn(
                name: "CLIENT_ID",
                table: "ITEM_CLIENT_TAB",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ITEM_ID",
                table: "ITEM_CLIENT_TAB",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ITEM_CLIENT_TAB_CLIENT_ID",
                table: "ITEM_CLIENT_TAB",
                newName: "IX_ITEM_CLIENT_TAB_ClientId");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "ITEM_TAB",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(38,17)");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_CLIENT_TAB_CLIENT_TAB_ClientId",
                table: "ITEM_CLIENT_TAB",
                column: "ClientId",
                principalTable: "CLIENT_TAB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_CLIENT_TAB_ITEM_TAB_ItemId",
                table: "ITEM_CLIENT_TAB",
                column: "ItemId",
                principalTable: "ITEM_TAB",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
