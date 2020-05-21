using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class AlterColumnsOnShippingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ShippingCharge",
                table: "Shipments",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShipmentDate",
                table: "Shipments",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CourierName",
                table: "Shipments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourierDetails",
                table: "Shipments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ShippingCharge",
                table: "Shipments",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShipmentDate",
                table: "Shipments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourierName",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourierDetails",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 5, 20, 13, 40, 7, 255, DateTimeKind.Local).AddTicks(2395) });
        }
    }
}
