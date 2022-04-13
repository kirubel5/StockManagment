using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Elements_Element",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_Element",
                table: "LineItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LineItems_Element",
                table: "LineItems",
                column: "Element");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Elements_Element",
                table: "LineItems",
                column: "Element",
                principalTable: "Elements",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
