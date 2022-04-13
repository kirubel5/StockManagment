using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_ObjectTypes_Type",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "LineItems",
                newName: "Reference");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_Type",
                table: "LineItems",
                newName: "IX_LineItems_Reference");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Vouchers_Reference",
                table: "LineItems",
                column: "Reference",
                principalTable: "Vouchers",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Elements_Element",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Vouchers_Reference",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_Element",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "LineItems",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_Reference",
                table: "LineItems",
                newName: "IX_LineItems_Type");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_ObjectTypes_Type",
                table: "LineItems",
                column: "Type",
                principalTable: "ObjectTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
