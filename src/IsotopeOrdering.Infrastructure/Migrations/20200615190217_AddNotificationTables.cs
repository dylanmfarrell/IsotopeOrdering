using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IsotopeOrdering.Infrastructure.Migrations {
    public partial class AddNotificationTables : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "NotificationConfigurations",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Target = table.Column<int>(nullable: false),
                    EventTrigger = table.Column<string>(nullable: false),
                    TemplatePath = table.Column<string>(nullable: false),
                    LastProcessed = table.Column<DateTime>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_NotificationConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RecipientName = table.Column<string>(nullable: false),
                    RecipientEmail = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    SentDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSubscriptions",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NotificationConfigurationId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_NotificationSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSubscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationSubscriptions_NotificationConfigurations_NotificationConfigurationId",
                        column: x => x.NotificationConfigurationId,
                        principalTable: "NotificationConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "NotificationConfigurations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EventTrigger", "IsDeleted", "LastProcessed", "Target", "TemplatePath", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 43, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment shipped", false, null, 1, "ShipmentShipped", "Shipment shipped", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 27, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order in process", false, null, 1, "OrderInProcess", "Order in process", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 28, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order in process", false, null, 0, "OrderInProcess", "Order in process", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 29, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order amended", false, null, 1, "OrderAmended", "Order amended", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 30, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order amended", false, null, 0, "OrderAmended", "Order amended", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 31, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Approved amended order", false, null, 1, "OrderApprovedAmendedOrder", "Approved amended order", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 32, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Approved amended order", false, null, 0, "OrderApprovedAmendedOrder", "Approved amended order", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 33, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order completed", false, null, 1, "OrderComplete", "Order completed", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 44, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment shipped", false, null, 0, "ShipmentShipped", "Shipment shipped", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 34, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order completed", false, null, 0, "OrderComplete", "Order completed", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 36, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order cancelled", false, null, 0, "OrderCancelled", "Order cancelled", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 26, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order denied", false, null, 0, "OrderDenied", "Order denied", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 38, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment created", false, null, 0, "ShipmentCreated", "Shipment created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 39, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment edited", false, null, 1, "ShipmentEdited", "Shipment edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 40, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment edited", false, null, 0, "ShipmentEdited", "Shipment edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 41, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment cancelled", false, null, 1, "ShipmentCancelled", "Shipment cancelled", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 42, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment cancelled", false, null, 0, "ShipmentCancelled", "Shipment cancelled", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 35, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order cancelled", false, null, 1, "OrderCancelled", "Order cancelled", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 37, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Shipment created", false, null, 1, "ShipmentCreated", "Shipment created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 25, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order denied", false, null, 1, "OrderDenied", "Order denied", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 23, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order approved", false, null, 1, "OrderApproved", "Order approved", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 2, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer created", false, null, 0, "CustomerCreated", "Customer created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 3, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer edited", false, null, 1, "CustomerEdited", "Customer edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 4, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer edited", false, null, 0, "CustomerEdited", "Customer edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 5, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has obtained initiation form", false, null, 1, "CustomerObtainedInitiationForm", "Customer has obtained initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 6, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has obtained initiation form", false, null, 0, "CustomerObtainedInitiationForm", "Customer has obtained initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 7, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted initiation form", false, null, 1, "CustomerSubmittedInitiationForm", "Customer has submitted initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 8, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted initiation form", false, null, 0, "CustomerSubmittedInitiationForm", "Customer has submitted initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 9, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has resubmitted initiation form", false, null, 1, "CustomerResubmittedInitiationForm", "Customer has resubmitted initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 10, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has resubmitted initiation form", false, null, 0, "CustomerResubmittedInitiationForm", "Customer has resubmitted initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 11, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted an invalid initiation form", false, null, 1, "CustomerValidationFailedInitiationForm", "Customer has submitted an invalid initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 12, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted an invalid initiation form", false, null, 0, "CustomerValidationFailedInitiationForm", "Customer has submitted an invalid initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 13, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted a valid initiation form", false, null, 1, "CustomerSubmissionSuccessInitiationForm", "Customer has submitted a valid initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 14, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer has submitted a valid initiation form", false, null, 0, "CustomerSubmissionSuccessInitiationForm", "Customer has submitted a valid initiation form", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 15, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Form status changed", false, null, 1, "CustomerFormStatusChanged", "Form status changed", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 16, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Form status changed", false, null, 0, "CustomerFormStatusChanged", "Form status changed", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 17, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order created", false, null, 1, "OrderCreated", "Order created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 18, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order created", false, null, 0, "OrderCreated", "Order created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 19, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order edited", false, null, 1, "OrderEdited", "Order edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 20, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order edited", false, null, 0, "OrderEdited", "Order edited", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 21, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order sent", false, null, 1, "OrderSent", "Order sent", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 22, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order sent", false, null, 0, "OrderSent", "Order sent", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 24, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Order approved", false, null, 0, "OrderApproved", "Order approved", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 1, "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546), "Customer created", false, null, 1, "CustomerCreated", "Customer created", "SYSTEM", new DateTime(2020, 6, 15, 14, 2, 17, 424, DateTimeKind.Local).AddTicks(546) }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSubscriptions_CustomerId",
                table: "NotificationSubscriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSubscriptions_NotificationConfigurationId",
                table: "NotificationSubscriptions",
                column: "NotificationConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "NotificationConfigurations");

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
    }
}
