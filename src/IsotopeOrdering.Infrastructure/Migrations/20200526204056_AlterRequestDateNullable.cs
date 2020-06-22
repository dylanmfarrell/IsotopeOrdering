using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IsotopeOrdering.Infrastructure.Migrations {
    public partial class AlterRequestDateNullable : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 5, 26, 15, 40, 56, 200, DateTimeKind.Local).AddTicks(224) });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135), new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135), new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135), new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135), new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135), new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135), new DateTime(2020, 5, 26, 9, 9, 57, 787, DateTimeKind.Local).AddTicks(7135) });
        }
    }
}
