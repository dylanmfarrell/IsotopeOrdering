using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class RemoveInstitutionFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Institutions_InstitutionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InstitutionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 5, 7, 15, 3, 22, 9, DateTimeKind.Local).AddTicks(8094) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "ItemConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104), new DateTime(2020, 5, 4, 14, 28, 46, 912, DateTimeKind.Local).AddTicks(104) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InstitutionId",
                table: "Orders",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Institutions_InstitutionId",
                table: "Orders",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
