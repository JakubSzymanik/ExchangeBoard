using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class NonmatchRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NonMatches");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "NonMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemAID = table.Column<int>(type: "int", nullable: false),
                    ItemBID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonMatches_Items_ItemAID",
                        column: x => x.ItemAID,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NonMatches_Items_ItemBID",
                        column: x => x.ItemBID,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NonMatches_ItemAID",
                table: "NonMatches",
                column: "ItemAID");

            migrationBuilder.CreateIndex(
                name: "IX_NonMatches_ItemBID",
                table: "NonMatches",
                column: "ItemBID");
        }
    }
}
