using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class UpdateDocumentColumnsToNullableNameAndDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440), new DateTime(2020, 7, 30, 10, 6, 53, 741, DateTimeKind.Local).AddTicks(9440) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 7, 7, 10, 37, 35, 634, DateTimeKind.Local).AddTicks(9943) });
        }
    }
}
