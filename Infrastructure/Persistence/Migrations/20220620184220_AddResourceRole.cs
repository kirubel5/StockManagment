using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddResourceRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "RoleModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ResourceRoles",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceRoles");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            //migrationBuilder.CreateTable(
            //    name: "RoleModels",
            //    columns: table => new
            //    {
            //        Name = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
            //        ConsigneeCreate = table.Column<bool>(type: "bit", nullable: false),
            //        ConsigneeDelete = table.Column<bool>(type: "bit", nullable: false),
            //        ConsigneeRead = table.Column<bool>(type: "bit", nullable: false),
            //        ConsigneeUpdate = table.Column<bool>(type: "bit", nullable: false),
            //        ElementCreate = table.Column<bool>(type: "bit", nullable: false),
            //        ElementDelete = table.Column<bool>(type: "bit", nullable: false),
            //        ElementRead = table.Column<bool>(type: "bit", nullable: false),
            //        ElementUpdate = table.Column<bool>(type: "bit", nullable: false),
            //        PersonCreate = table.Column<bool>(type: "bit", nullable: false),
            //        PersonDelete = table.Column<bool>(type: "bit", nullable: false),
            //        PersonRead = table.Column<bool>(type: "bit", nullable: false),
            //        PersonUpdate = table.Column<bool>(type: "bit", nullable: false),
            //        VoucherCreate = table.Column<bool>(type: "bit", nullable: false),
            //        VoucherDelete = table.Column<bool>(type: "bit", nullable: false),
            //        VoucherRead = table.Column<bool>(type: "bit", nullable: false),
            //        VoucherUpdate = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleModels", x => x.Name);
            //    });
        }
    }
}
