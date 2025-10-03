using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMenuAndTheirItensFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_menu_MenuId",
                table: "menu_item");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_menu_MenuId_RestaurantId",
                table: "menu_item");

            migrationBuilder.DropIndex(
                name: "IX_menu_item_MenuId_RestaurantId",
                table: "menu_item");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_menu_Id_RestaurantId",
                table: "menu");

            migrationBuilder.DropIndex(
                name: "IX_menu_Id_RestaurantId",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "menu_item");

            migrationBuilder.CreateTable(
                name: "menu_menu_item",
                columns: table => new
                {
                    ItensId = table.Column<long>(type: "bigint", nullable: false),
                    MenusId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_menu_item", x => new { x.ItensId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_menu_menu_item_menu_MenusId",
                        column: x => x.MenusId,
                        principalTable: "menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_menu_item_menu_item_ItensId",
                        column: x => x.ItensId,
                        principalTable: "menu_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_menu_menu_item_MenusId",
                table: "menu_menu_item",
                column: "MenusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_menu_item");

            migrationBuilder.AddColumn<long>(
                name: "MenuId",
                table: "menu_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_menu_Id_RestaurantId",
                table: "menu",
                columns: new[] { "Id", "RestaurantId" });

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_MenuId_RestaurantId",
                table: "menu_item",
                columns: new[] { "MenuId", "RestaurantId" });

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
        }
    }
}
