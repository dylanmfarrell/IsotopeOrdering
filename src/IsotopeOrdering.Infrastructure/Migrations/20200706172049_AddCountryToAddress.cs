using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IsotopeOrdering.Infrastructure.Migrations {
    public partial class AddCountryToAddress : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_Country",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping_Country",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Institutions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "CustomerAddresses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), "DefaultTemplate.cshtml", new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697), new DateTime(2020, 7, 6, 12, 20, 49, 245, DateTimeKind.Local).AddTicks(9697) });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Billing_Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Shipping_Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "CustomerAddresses");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerCreated.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerCreated.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerEdited.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerEdited.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerSubmittedInitiationForm.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerSubmittedInitiationForm.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerFormStatusChanged.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "CustomerFormStatusChanged.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderCreated.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderCreated.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderEdited.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderEdited.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderSent.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderSent.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderApproved.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderApproved.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderDenied.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderDenied.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderInProcess.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderInProcess.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderAmended.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderAmended.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderApprovedAmendedOrder.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderApprovedAmendedOrder.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderComplete.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderComplete.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderCancelled.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "OrderCancelled.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentCreated.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentCreated.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentEdited.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentEdited.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentCancelled.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentCancelled.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentShipped.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), "ShipmentShipped.cshtml", new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124), new DateTime(2020, 6, 25, 9, 20, 0, 389, DateTimeKind.Local).AddTicks(124) });
        }
    }
}
