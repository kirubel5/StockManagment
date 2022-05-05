using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "SubTotal",
                table: "Vouchers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<float>(
                name: "GrandTotal",
                table: "Vouchers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<float>(
                name: "UnitAmount",
                table: "LineItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<float>(
                name: "TaxableAmount",
                table: "LineItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<float>(
                name: "TaxAmount",
                table: "LineItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Quantity",
                table: "LineItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.CreateTable(
                name: "RoleModels",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    ConsigneeCreate = table.Column<bool>(type: "bit", nullable: false),
                    ConsigneeRead = table.Column<bool>(type: "bit", nullable: false),
                    ConsigneeUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ConsigneeDelete = table.Column<bool>(type: "bit", nullable: false),
                    ElementCreate = table.Column<bool>(type: "bit", nullable: false),
                    ElementRead = table.Column<bool>(type: "bit", nullable: false),
                    ElementUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ElementDelete = table.Column<bool>(type: "bit", nullable: false),
                    PersonCreate = table.Column<bool>(type: "bit", nullable: false),
                    PersonRead = table.Column<bool>(type: "bit", nullable: false),
                    PersonUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PersonDelete = table.Column<bool>(type: "bit", nullable: false),
                    VoucherCreate = table.Column<bool>(type: "bit", nullable: false),
                    VoucherRead = table.Column<bool>(type: "bit", nullable: false),
                    VoucherUpdate = table.Column<bool>(type: "bit", nullable: false),
                    VoucherDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModels", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleModels");

            migrationBuilder.AlterColumn<double>(
                name: "SubTotal",
                table: "Vouchers",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "GrandTotal",
                table: "Vouchers",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "UnitAmount",
                table: "LineItems",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "TaxableAmount",
                table: "LineItems",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "TaxAmount",
                table: "LineItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "LineItems",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
