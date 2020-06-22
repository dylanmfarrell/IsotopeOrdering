using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IsotopeOrdering.Infrastructure.Migrations {
    public partial class AddBillingContactToOrder : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "BillingContact_Email",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingContact_Fax",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingContact_FirstName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingContact_LastName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingContact_PhoneNumber",
                table: "Orders",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "BillingContact_Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingContact_Fax",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingContact_FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingContact_LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingContact_PhoneNumber",
                table: "Orders");

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
        }
    }
}
