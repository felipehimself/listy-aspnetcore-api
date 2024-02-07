using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ListMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems");

            migrationBuilder.RenameTable(
                name: "ListItems",
                newName: "list_items");

            migrationBuilder.RenameIndex(
                name: "IX_ListItems_ListId",
                table: "list_items",
                newName: "IX_list_items_ListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_list_items",
                table: "list_items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_list_items_Lists_ListId",
                table: "list_items",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_list_items_Lists_ListId",
                table: "list_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_list_items",
                table: "list_items");

            migrationBuilder.RenameTable(
                name: "list_items",
                newName: "ListItems");

            migrationBuilder.RenameIndex(
                name: "IX_list_items_ListId",
                table: "ListItems",
                newName: "IX_ListItems_ListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
