using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_list_items_Lists_ListId",
                table: "list_items");

            migrationBuilder.DropIndex(
                name: "IX_list_items_ListId",
                table: "list_items");

            migrationBuilder.AddColumn<Guid>(
                name: "ListEntityId",
                table: "list_items",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_list_items_ListEntityId",
                table: "list_items",
                column: "ListEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_list_items_Lists_ListEntityId",
                table: "list_items",
                column: "ListEntityId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_list_items_Lists_ListEntityId",
                table: "list_items");

            migrationBuilder.DropIndex(
                name: "IX_list_items_ListEntityId",
                table: "list_items");

            migrationBuilder.DropColumn(
                name: "ListEntityId",
                table: "list_items");

            migrationBuilder.CreateIndex(
                name: "IX_list_items_ListId",
                table: "list_items",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_list_items_Lists_ListId",
                table: "list_items",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
