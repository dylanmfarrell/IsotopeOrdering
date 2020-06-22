using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IsotopeOrdering.Infrastructure.Migrations {
    public partial class UpdateCustomerIdOnItemConfigurations : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemConfigurations_Customers_CustomerId",
                table: "ItemConfigurations");

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

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ItemConfigurations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555), new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555), new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555), new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555), new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555), new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555), new DateTime(2020, 5, 22, 11, 11, 51, 930, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemConfigurations_Customers_CustomerId",
                table: "ItemConfigurations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemConfigurations_Customers_CustomerId",
                table: "ItemConfigurations");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ItemConfigurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) });

            migrationBuilder.InsertData(
                table: "ItemConfigurations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CustomerId", "IsDeleted", "ItemId", "MaximumAmount", "MinimumAmount", "Price", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 1, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), null, false, 1, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 2, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), null, false, 2, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 3, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), null, false, 3, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 4, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), null, false, 4, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 5, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26), null, false, 5, 100m, 0m, 1000m, "SYSTEM", new DateTime(2020, 5, 21, 9, 23, 22, 74, DateTimeKind.Local).AddTicks(26) }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemConfigurations_Customers_CustomerId",
                table: "ItemConfigurations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
