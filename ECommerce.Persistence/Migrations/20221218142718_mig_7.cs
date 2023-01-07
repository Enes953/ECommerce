using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    public partial class mig_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ImageFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_ProductId",
                table: "ImageFiles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFiles_Products_ProductId",
                table: "ImageFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_Products_ProductId",
                table: "ImageFiles");

            migrationBuilder.DropIndex(
                name: "IX_ImageFiles_ProductId",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ImageFiles");
        }
    }
}
