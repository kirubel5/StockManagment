using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class IterateLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Elements_ElementCode",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Vouchers_ReferenceCode",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ElementCode",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "ElementCode",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "ReferenceCode",
                table: "LineItems",
                newName: "VoucherCode");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ReferenceCode",
                table: "LineItems",
                newName: "IX_LineItems_VoucherCode");

            migrationBuilder.AddColumn<string>(
                name: "Element",
                table: "LineItems",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "LineItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Vouchers_VoucherCode",
                table: "LineItems",
                column: "VoucherCode",
                principalTable: "Vouchers",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Vouchers_VoucherCode",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Element",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "VoucherCode",
                table: "LineItems",
                newName: "ReferenceCode");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_VoucherCode",
                table: "LineItems",
                newName: "IX_LineItems_ReferenceCode");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Vouchers_ReferenceCode",
                table: "LineItems",
                column: "ReferenceCode",
                principalTable: "Vouchers",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
