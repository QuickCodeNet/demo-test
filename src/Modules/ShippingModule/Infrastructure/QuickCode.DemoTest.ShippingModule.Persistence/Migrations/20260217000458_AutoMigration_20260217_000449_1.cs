using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoTest.ShippingModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260217_000449_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIT_LOGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ENTITY_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_GROUP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TIMESTAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OLD_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    NEW_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CHANGED_COLUMNS = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IS_CHANGED = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CHANGE_SUMMARY = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_AGENT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CORRELATION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_SUCCESS = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ERROR_MESSAGE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    HASH = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_LOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY_ADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_LINE_1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ADDRESS_LINE_2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ZIP_CODE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    COUNTRY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_ADDRESSES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPING_CARRIERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TRACKING_URL_FORMAT = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPING_CARRIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPING_RATES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CARRIER_ID = table.Column<int>(type: "int", nullable: false),
                    DESTINATION_ZIP_CODE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WEIGHT_FROM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WEIGHT_TO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPING_RATES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHIPMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    SHIPPING_CARRIER_ID = table.Column<int>(type: "int", nullable: false),
                    TRACKING_NUMBER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SHIPPING_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ESTIMATED_DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACTUAL_DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SHIPPING_STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    SHIPPING_COST = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DELIVERY_ADDRESS_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SHIPMENTS_DELIVERY_ADDRESSES_DELIVERY_ADDRESS_ID",
                        column: x => x.DELIVERY_ADDRESS_ID,
                        principalTable: "DELIVERY_ADDRESSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHIPMENTS_SHIPPING_CARRIERS_SHIPPING_CARRIER_ID",
                        column: x => x.SHIPPING_CARRIER_ID,
                        principalTable: "SHIPPING_CARRIERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY_EXCEPTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SHIPMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EXCEPTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EXCEPTION_REASON = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_EXCEPTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DELIVERY_EXCEPTIONS_SHIPMENTS_SHIPMENT_ID",
                        column: x => x.SHIPMENT_ID,
                        principalTable: "SHIPMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SHIPMENT_TRACKING_EVENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SHIPMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EVENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EVENT_LOCATION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EVENT_DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPMENT_TRACKING_EVENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SHIPMENT_TRACKING_EVENTS_SHIPMENTS_SHIPMENT_ID",
                        column: x => x.SHIPMENT_ID,
                        principalTable: "SHIPMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERY_ADDRESSES_IsDeleted",
                table: "DELIVERY_ADDRESSES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERY_EXCEPTIONS_IsDeleted",
                table: "DELIVERY_EXCEPTIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERY_EXCEPTIONS_SHIPMENT_ID",
                table: "DELIVERY_EXCEPTIONS",
                column: "SHIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENT_TRACKING_EVENTS_IsDeleted",
                table: "SHIPMENT_TRACKING_EVENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENT_TRACKING_EVENTS_SHIPMENT_ID",
                table: "SHIPMENT_TRACKING_EVENTS",
                column: "SHIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_DELIVERY_ADDRESS_ID",
                table: "SHIPMENTS",
                column: "DELIVERY_ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_IsDeleted",
                table: "SHIPMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_SHIPPING_CARRIER_ID",
                table: "SHIPMENTS",
                column: "SHIPPING_CARRIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_CARRIERS_IsDeleted",
                table: "SHIPPING_CARRIERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_RATES_IsDeleted",
                table: "SHIPPING_RATES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "DELIVERY_EXCEPTIONS");

            migrationBuilder.DropTable(
                name: "SHIPMENT_TRACKING_EVENTS");

            migrationBuilder.DropTable(
                name: "SHIPPING_RATES");

            migrationBuilder.DropTable(
                name: "SHIPMENTS");

            migrationBuilder.DropTable(
                name: "DELIVERY_ADDRESSES");

            migrationBuilder.DropTable(
                name: "SHIPPING_CARRIERS");
        }
    }
}
