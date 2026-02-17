using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoTest.InventoryModule.Persistence.Migrations
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
                name: "SUPPLIERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONTACT_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CONTACT_EMAIL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CONTACT_PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LOCATION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY_ADJUSTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    ADJUSTMENT_QUANTITY = table.Column<int>(type: "int", nullable: false),
                    ADJUSTMENT_REASON = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ADJUSTMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_ADJUSTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVENTORY_ADJUSTMENTS_WAREHOUSES_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REORDER_POINTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    REORDER_QUANTITY = table.Column<int>(type: "int", nullable: false),
                    MINIMUM_STOCK_LEVEL = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REORDER_POINTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REORDER_POINTS_WAREHOUSES_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOCK_MOVEMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    MOVEMENT_TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    MOVEMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_MOVEMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STOCK_MOVEMENTS_WAREHOUSES_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOCKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    LAST_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STOCKS_WAREHOUSES_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_ADJUSTMENTS_IsDeleted",
                table: "INVENTORY_ADJUSTMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_ADJUSTMENTS_WAREHOUSE_ID",
                table: "INVENTORY_ADJUSTMENTS",
                column: "WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REORDER_POINTS_IsDeleted",
                table: "REORDER_POINTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_REORDER_POINTS_WAREHOUSE_ID",
                table: "REORDER_POINTS",
                column: "WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVEMENTS_IsDeleted",
                table: "STOCK_MOVEMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVEMENTS_WAREHOUSE_ID",
                table: "STOCK_MOVEMENTS",
                column: "WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCKS_IsDeleted",
                table: "STOCKS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_STOCKS_WAREHOUSE_ID",
                table: "STOCKS",
                column: "WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIERS_IsDeleted",
                table: "SUPPLIERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_WAREHOUSES_IsDeleted",
                table: "WAREHOUSES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "INVENTORY_ADJUSTMENTS");

            migrationBuilder.DropTable(
                name: "REORDER_POINTS");

            migrationBuilder.DropTable(
                name: "STOCK_MOVEMENTS");

            migrationBuilder.DropTable(
                name: "STOCKS");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "WAREHOUSES");
        }
    }
}
