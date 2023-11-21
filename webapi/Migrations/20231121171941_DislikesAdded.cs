using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class DislikesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Items_ItemAID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Items_ItemBID",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "ItemBID",
                table: "Matches",
                newName: "ItemBId");

            migrationBuilder.RenameColumn(
                name: "ItemAID",
                table: "Matches",
                newName: "ItemAId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_ItemBID",
                table: "Matches",
                newName: "IX_Matches_ItemBId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_ItemAID",
                table: "Matches",
                newName: "IX_Matches_ItemAId");

            migrationBuilder.CreateTable(
                name: "Dislikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    TargetItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dislikes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dislikes_Items_TargetItemId",
                        column: x => x.TargetItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_ItemId",
                table: "Dislikes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_TargetItemId",
                table: "Dislikes",
                column: "TargetItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Items_ItemAId",
                table: "Matches",
                column: "ItemAId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Items_ItemBId",
                table: "Matches",
                column: "ItemBId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Items_ItemAId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Items_ItemBId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Dislikes");

            migrationBuilder.RenameColumn(
                name: "ItemBId",
                table: "Matches",
                newName: "ItemBID");

            migrationBuilder.RenameColumn(
                name: "ItemAId",
                table: "Matches",
                newName: "ItemAID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_ItemBId",
                table: "Matches",
                newName: "IX_Matches_ItemBID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_ItemAId",
                table: "Matches",
                newName: "IX_Matches_ItemAID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Items_ItemAID",
                table: "Matches",
                column: "ItemAID",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Items_ItemBID",
                table: "Matches",
                column: "ItemBID",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
