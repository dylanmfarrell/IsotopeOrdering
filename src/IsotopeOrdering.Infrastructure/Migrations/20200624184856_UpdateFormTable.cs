using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsotopeOrdering.Infrastructure.Migrations
{
    public partial class UpdateFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.AddColumn<Guid>(
                name: "FormIdentifier",
                table: "CustomerForms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "CustomerCreated.cshtml", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "CustomerCreated.cshtml", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "CustomerEdited.cshtml", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "CustomerEdited.cshtml", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Customer has submitted initiation form", "CustomerSubmittedInitiationForm.cshtml", "Customer has submitted initiation form", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Customer has submitted initiation form", "CustomerSubmittedInitiationForm.cshtml", "Customer has submitted initiation form", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Form status changed", "CustomerFormStatusChanged.cshtml", "Form status changed", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Form status changed", "CustomerFormStatusChanged.cshtml", "Form status changed", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order created", "OrderCreated.cshtml", "Order created", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order created", "OrderCreated.cshtml", "Order created", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order edited", "OrderEdited.cshtml", "Order edited", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order edited", "OrderEdited.cshtml", "Order edited", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order sent", "OrderSent.cshtml", "Order sent", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order sent", "OrderSent.cshtml", "Order sent", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order approved", "OrderApproved.cshtml", "Order approved", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order approved", "OrderApproved.cshtml", "Order approved", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order denied", "OrderDenied.cshtml", "Order denied", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order denied", "OrderDenied.cshtml", "Order denied", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order in process", "OrderInProcess.cshtml", "Order in process", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order in process", "OrderInProcess.cshtml", "Order in process", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order amended", "OrderAmended.cshtml", "Order amended", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order amended", "OrderAmended.cshtml", "Order amended", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Approved amended order", "OrderApprovedAmendedOrder.cshtml", "Approved amended order", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Approved amended order", "OrderApprovedAmendedOrder.cshtml", "Approved amended order", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order completed", "OrderComplete.cshtml", "Order completed", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order completed", "OrderComplete.cshtml", "Order completed", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order cancelled", "OrderCancelled.cshtml", "Order cancelled", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Order cancelled", "OrderCancelled.cshtml", "Order cancelled", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment created", "ShipmentCreated.cshtml", "Shipment created", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment created", "ShipmentCreated.cshtml", "Shipment created", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment edited", "ShipmentEdited.cshtml", "Shipment edited", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment edited", "ShipmentEdited.cshtml", "Shipment edited", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment cancelled", "ShipmentCancelled.cshtml", "Shipment cancelled", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment cancelled", "ShipmentCancelled.cshtml", "Shipment cancelled", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment shipped", "ShipmentShipped.cshtml", "Shipment shipped", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "Shipment shipped", "ShipmentShipped.cshtml", "Shipment shipped", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "EventTrigger", "Target", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266), "", 2, "MaterialTransferAgreement.cshtml", "A customer has requested approval for their material transfer agreement", new DateTime(2020, 6, 24, 13, 48, 55, 477, DateTimeKind.Local).AddTicks(3266) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormIdentifier",
                table: "CustomerForms");

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "CustomerCreated", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "CustomerCreated", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "CustomerEdited", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "TemplatePath", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "CustomerEdited", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has obtained initiation form", "CustomerObtainedInitiationForm", "Customer has obtained initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has obtained initiation form", "CustomerObtainedInitiationForm", "Customer has obtained initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted initiation form", "CustomerSubmittedInitiationForm", "Customer has submitted initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted initiation form", "CustomerSubmittedInitiationForm", "Customer has submitted initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has resubmitted initiation form", "CustomerResubmittedInitiationForm", "Customer has resubmitted initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has resubmitted initiation form", "CustomerResubmittedInitiationForm", "Customer has resubmitted initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted an invalid initiation form", "CustomerValidationFailedInitiationForm", "Customer has submitted an invalid initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted an invalid initiation form", "CustomerValidationFailedInitiationForm", "Customer has submitted an invalid initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted a valid initiation form", "CustomerSubmissionSuccessInitiationForm", "Customer has submitted a valid initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted a valid initiation form", "CustomerSubmissionSuccessInitiationForm", "Customer has submitted a valid initiation form", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Form status changed", "CustomerFormStatusChanged", "Form status changed", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Form status changed", "CustomerFormStatusChanged", "Form status changed", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order created", "OrderCreated", "Order created", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order created", "OrderCreated", "Order created", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order edited", "OrderEdited", "Order edited", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order edited", "OrderEdited", "Order edited", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order sent", "OrderSent", "Order sent", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order sent", "OrderSent", "Order sent", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order approved", "OrderApproved", "Order approved", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order approved", "OrderApproved", "Order approved", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order denied", "OrderDenied", "Order denied", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order denied", "OrderDenied", "Order denied", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order in process", "OrderInProcess", "Order in process", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order in process", "OrderInProcess", "Order in process", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order amended", "OrderAmended", "Order amended", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order amended", "OrderAmended", "Order amended", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Approved amended order", "OrderApprovedAmendedOrder", "Approved amended order", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Approved amended order", "OrderApprovedAmendedOrder", "Approved amended order", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order completed", "OrderComplete", "Order completed", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order completed", "OrderComplete", "Order completed", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order cancelled", "OrderCancelled", "Order cancelled", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "EventTrigger", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order cancelled", "OrderCancelled", "Order cancelled", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "NotificationConfigurations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "EventTrigger", "Target", "TemplatePath", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment created", 1, "ShipmentCreated", "Shipment created", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.InsertData(
                table: "NotificationConfigurations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EventTrigger", "IsDeleted", "LastProcessed", "Target", "TemplatePath", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 39, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment edited", false, null, 1, "ShipmentEdited", "Shipment edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 40, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment edited", false, null, 0, "ShipmentEdited", "Shipment edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 43, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment shipped", false, null, 1, "ShipmentShipped", "Shipment shipped", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 42, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment cancelled", false, null, 0, "ShipmentCancelled", "Shipment cancelled", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 44, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment shipped", false, null, 0, "ShipmentShipped", "Shipment shipped", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 41, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment cancelled", false, null, 1, "ShipmentCancelled", "Shipment cancelled", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 38, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment created", false, null, 0, "ShipmentCreated", "Shipment created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                });
        }
    }
}
