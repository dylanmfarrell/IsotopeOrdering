using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IsotopeOrdering.Infrastructure.Migrations {
    public partial class InitialCreate : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ParentCustomerId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    FedExNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    InternalNotes = table.Column<string>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Customers_ParentCustomerId",
                        column: x => x.ParentCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityEvents",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDateTime = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_EntityEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    MaxLimit = table.Column<decimal>(nullable: false),
                    SafetyContact_FirstName = table.Column<string>(nullable: true),
                    SafetyContact_LastName = table.Column<string>(nullable: true),
                    SafetyContact_Email = table.Column<string>(nullable: true),
                    SafetyContact_PhoneNumber = table.Column<string>(nullable: true),
                    SafetyContact_Fax = table.Column<string>(nullable: true),
                    FinancialContact_FirstName = table.Column<string>(nullable: true),
                    FinancialContact_LastName = table.Column<string>(nullable: true),
                    FinancialContact_Email = table.Column<string>(nullable: true),
                    FinancialContact_PhoneNumber = table.Column<string>(nullable: true),
                    FinancialContact_Fax = table.Column<string>(nullable: true),
                    AddressName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    Document_Name = table.Column<string>(nullable: true),
                    Document_Details = table.Column<string>(nullable: true),
                    Document_UploadId = table.Column<Guid>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Unavailable = table.Column<bool>(nullable: false),
                    Target = table.Column<string>(nullable: false),
                    Reaction = table.Column<string>(nullable: false),
                    FinalComposition = table.Column<string>(nullable: false),
                    SpecificActivity = table.Column<string>(nullable: false),
                    QualityControlAnalysis = table.Column<string>(nullable: false),
                    MinQuantity = table.Column<decimal>(nullable: true),
                    MaxQuantity = table.Column<decimal>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CourierName = table.Column<string>(nullable: false),
                    CourierDetails = table.Column<string>(nullable: false),
                    ShippingCharge = table.Column<decimal>(nullable: false),
                    AddressName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    Document_Name = table.Column<string>(nullable: true),
                    Document_Details = table.Column<string>(nullable: true),
                    Document_UploadId = table.Column<Guid>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDocuments",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    UploadId = table.Column<Guid>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_CustomerDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDocuments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerForms",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FormData = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_CustomerForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerForms_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerForms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInstitutions",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    Relationship = table.Column<int>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_CustomerInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInstitutions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInstitutions_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FedExNumber = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Shipping_Name = table.Column<string>(nullable: true),
                    Shipping_State = table.Column<string>(nullable: true),
                    Shipping_City = table.Column<string>(nullable: true),
                    Shipping_ZipCode = table.Column<string>(nullable: true),
                    Shipping_Address1 = table.Column<string>(nullable: true),
                    Shipping_Address2 = table.Column<string>(nullable: true),
                    Shipping_Address3 = table.Column<string>(nullable: true),
                    Billing_Name = table.Column<string>(nullable: true),
                    Billing_State = table.Column<string>(nullable: true),
                    Billing_City = table.Column<string>(nullable: true),
                    Billing_ZipCode = table.Column<string>(nullable: true),
                    Billing_Address1 = table.Column<string>(nullable: true),
                    Billing_Address2 = table.Column<string>(nullable: true),
                    Billing_Address3 = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemConfigurations",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    MinimumAmount = table.Column<decimal>(nullable: true),
                    MaximumAmount = table.Column<decimal>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ItemConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemConfigurations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemConfigurations_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ItemConfigurationId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SpecialInstructions = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_ItemConfigurations_ItemConfigurationId",
                        column: x => x.ItemConfigurationId,
                        principalTable: "ItemConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItems",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ShipmentId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ShippedRadioactivity = table.Column<decimal>(nullable: false),
                    DamagedReason = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ShipmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632), false, "Material Transfer Agreement", 0, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "FinalComposition", "IsDeleted", "MaxQuantity", "MinQuantity", "Name", "QualityControlAnalysis", "Reaction", "SpecificActivity", "Target", "Unavailable", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 1, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632), null, "Copper chloride", false, null, null, "Cu-64", "germanium spectrum", "(p,n)", "determined by TETA titration", "Ni-64", false, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 2, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632), null, "Yttrium chloride", false, null, null, "Y-86", "germanium spectrum", "(p,n)", "determined by TETA titration", "Sr-86", false, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 3, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632), null, "Bromide", false, null, null, "Br-76", "germanium spectrum", "(p,n)", "N/A", "Se-76", false, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 4, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632), null, "Bromide", false, null, null, "Br-77", "germanium spectrum", "(p,n)", "determined by TETA titration", "Se-77", false, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632) },
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    { 5, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632), null, "Zirconium Oxalate", false, null, null, "Zr-89", "germanium spectrum", "(p,n)", "determined by DFO titration", "Y-89", false, "SYSTEM", new DateTime(2020, 4, 10, 16, 17, 38, 293, DateTimeKind.Local).AddTicks(632) }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDocuments_CustomerId",
                table: "CustomerDocuments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerForms_CustomerId",
                table: "CustomerForms",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerForms_FormId",
                table: "CustomerForms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInstitutions_CustomerId",
                table: "CustomerInstitutions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInstitutions_InstitutionId",
                table: "CustomerInstitutions",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ParentCustomerId",
                table: "Customers",
                column: "ParentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConfigurations_CustomerId",
                table: "ItemConfigurations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConfigurations_ItemId",
                table: "ItemConfigurations",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemConfigurationId",
                table: "OrderItems",
                column: "ItemConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InstitutionId",
                table: "Orders",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_OrderItemId",
                table: "ShipmentItems",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_ShipmentId",
                table: "ShipmentItems",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerDocuments");

            migrationBuilder.DropTable(
                name: "CustomerForms");

            migrationBuilder.DropTable(
                name: "CustomerInstitutions");

            migrationBuilder.DropTable(
                name: "EntityEvents");

            migrationBuilder.DropTable(
                name: "ShipmentItems");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "ItemConfigurations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
