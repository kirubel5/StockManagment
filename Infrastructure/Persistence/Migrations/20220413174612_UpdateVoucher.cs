using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_ObjectTypes_Type",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_Type",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "LineItems",
                newName: "Reference");

            migrationBuilder.AlterColumn<string>(
                name: "Element",
                table: "LineItems",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "LineItems",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Element",
                table: "LineItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(26)",
                oldMaxLength: 26);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_Type",
                table: "LineItems",
                column: "Type");

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
