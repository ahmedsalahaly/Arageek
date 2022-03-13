using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arageek.Migrations
{
    public partial class mainObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mainCategoreys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainCategoreys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mainCategoreys_articals_articalId",
                        column: x => x.articalId,
                        principalTable: "articals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mainCategoreys_articalId",
                table: "mainCategoreys",
                column: "articalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mainCategoreys");
        }
    }
}
