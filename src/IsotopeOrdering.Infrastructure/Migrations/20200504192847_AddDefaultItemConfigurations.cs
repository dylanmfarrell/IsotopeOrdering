using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class AddDefaultItemConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.InsertData(
                table: "ItemConfigurations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CustomerId", "IsDeleted", "ItemId", "MaximumAmount", "MinimumAmount", "Price", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 1, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), null, false, 1, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 2, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), null, false, 2, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 3, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), null, false, 3, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 4, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), null, false, 4, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 5, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), null, false, 5, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 5);

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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 4, 24, 10, 39, 53, 389, DateTimeKind.Local).AddTicks(4210) });
        }
    }
}
