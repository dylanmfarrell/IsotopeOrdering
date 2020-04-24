using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class FixCustomerNullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "SpecificActivity", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), "N/A", new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "SpecificActivity", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), "N/A", new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738), new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738), new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "SpecificActivity", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738), "determined by TETA titration", new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738), new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "SpecificActivity", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738), "determined by TETA titration", new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738), new DateTime(2020, 4, 17, 10, 59, 26, 245, DateTimeKind.Local).AddTicks(2738) });
        }
    }
}
