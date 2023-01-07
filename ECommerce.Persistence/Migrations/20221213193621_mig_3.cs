using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImageFiles_ImageFileId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageFileId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageFileId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageFileId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageFileId",
                table: "Products",
                column: "ImageFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImageFiles_ImageFileId",
                table: "Products",
                column: "ImageFileId",
                principalTable: "ImageFiles",
                principalColumn: "Id");
        }
    }
}
