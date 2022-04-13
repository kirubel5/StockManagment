using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Element",
                table: "LineItems");

            migrationBuilder.AddColumn<string>(
                name: "ElementCode",
                table: "LineItems",
                type: "nvarchar(26)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ElementCode",
                table: "LineItems",
                column: "ElementCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Elements_ElementCode",
                table: "LineItems",
                column: "ElementCode",
                principalTable: "Elements",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Elements_ElementCode",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ElementCode",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "ElementCode",
                table: "LineItems");

            migrationBuilder.AddColumn<string>(
                name: "Element",
                table: "LineItems",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: false,
                defaultValue: "");
        }
    }
}
