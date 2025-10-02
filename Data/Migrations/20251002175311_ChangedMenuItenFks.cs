using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMenuItenFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_menu_MenuId",
                table: "menu_item");

            migrationBuilder.DropIndex(
                name: "IX_menu_item_MenuId",
                table: "menu_item");

            migrationBuilder.DropColumn(
                name: "Notas",
                table: "menu");

            migrationBuilder.AlterColumn<long>(
                name: "MenuId",
                table: "menu_item",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "RestaurantId",
                table: "menu_item",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_menu_Id_RestaurantId",
                table: "menu",
                columns: new[] { "Id", "RestaurantId" });

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_MenuId_RestaurantId",
                table: "menu_item",
                columns: new[] { "MenuId", "RestaurantId" });

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_RestaurantId",
                table: "menu_item",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_Id_RestaurantId",
                table: "menu",
                columns: new[] { "Id", "RestaurantId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_menu_MenuId",
                table: "menu_item",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_menu_MenuId_RestaurantId",
                table: "menu_item",
                columns: new[] { "MenuId", "RestaurantId" },
                principalTable: "menu",
                principalColumns: new[] { "Id", "RestaurantId" });

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_restaurant_RestaurantId",
                table: "menu_item",
                column: "RestaurantId",
                principalTable: "restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_menu_MenuId",
                table: "menu_item");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_menu_MenuId_RestaurantId",
                table: "menu_item");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_restaurant_RestaurantId",
                table: "menu_item");

            migrationBuilder.DropIndex(
                name: "IX_menu_item_MenuId_RestaurantId",
                table: "menu_item");

            migrationBuilder.DropIndex(
                name: "IX_menu_item_RestaurantId",
                table: "menu_item");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_menu_Id_RestaurantId",
                table: "menu");

            migrationBuilder.DropIndex(
                name: "IX_menu_Id_RestaurantId",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "menu_item");

            migrationBuilder.AlterColumn<long>(
                name: "MenuId",
                table: "menu_item",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "menu",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_MenuId",
                table: "menu_item",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_menu_MenuId",
                table: "menu_item",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
