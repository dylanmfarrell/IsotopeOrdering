using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class AddShipmentDateToShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDate",
                table: "Shipments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipmentDate",
                table: "Shipments");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 5, 11, 14, 38, 6, 108, DateTimeKind.Local).AddTicks(2819) });
        }
    }
}
