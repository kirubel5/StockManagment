using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consignees_ObjectTypes_Type",
                table: "Consignees");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Vouchers_VoucherCode",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_ObjectTypes_Type",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastOperation",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Elements");

            migrationBuilder.RenameColumn(
                name: "Element",
                table: "LineItems",
                newName: "ElementCode");

            migrationBuilder.RenameColumn(
                name: "Group",
                table: "Elements",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ConsigneeCode",
                table: "Vouchers",
                type: "nvarchar(26)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_ConsigneeCode",
                table: "Vouchers",
                column: "ConsigneeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Consignees_ObjectTypes_Type",
                table: "Consignees",
                column: "Type",
                principalTable: "ObjectTypes",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Vouchers_VoucherCode",
                table: "LineItems",
                column: "VoucherCode",
                principalTable: "Vouchers",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_ObjectTypes_Type",
                table: "Persons",
                column: "Type",
                principalTable: "ObjectTypes",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Consignees_ConsigneeCode",
                table: "Vouchers",
                column: "ConsigneeCode",
                principalTable: "Consignees",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consignees_ObjectTypes_Type",
                table: "Consignees");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Vouchers_VoucherCode",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_ObjectTypes_Type",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Consignees_ConsigneeCode",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_ConsigneeCode",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "ConsigneeCode",
                table: "Vouchers");

            migrationBuilder.RenameColumn(
                name: "ElementCode",
                table: "LineItems",
                newName: "Element");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Elements",
                newName: "Group");

            migrationBuilder.AddColumn<string>(
                name: "LastOperation",
                table: "Vouchers",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Vouchers",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "LineItems",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Elements",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Elements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consignees_ObjectTypes_Type",
                table: "Consignees",
                column: "Type",
                principalTable: "ObjectTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Vouchers_VoucherCode",
                table: "LineItems",
                column: "VoucherCode",
                principalTable: "Vouchers",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_ObjectTypes_Type",
                table: "Persons",
                column: "Type",
                principalTable: "ObjectTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
