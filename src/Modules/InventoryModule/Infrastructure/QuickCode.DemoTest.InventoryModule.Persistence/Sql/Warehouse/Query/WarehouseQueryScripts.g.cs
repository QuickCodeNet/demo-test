namespace QuickCode.DemoTest.InventoryModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Warehouse
    {
        public static class Query
        {
            private const string _prefix = "InventoryModule.Warehouse.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetStocksForWarehouses => ResourceKey("GetStocksForWarehouses.g.sql");
            public static string GetStocksForWarehousesDetails => ResourceKey("GetStocksForWarehousesDetails.g.sql");
            public static string GetStockMovementsForWarehouses => ResourceKey("GetStockMovementsForWarehouses.g.sql");
            public static string GetStockMovementsForWarehousesDetails => ResourceKey("GetStockMovementsForWarehousesDetails.g.sql");
            public static string GetReorderPointsForWarehouses => ResourceKey("GetReorderPointsForWarehouses.g.sql");
            public static string GetReorderPointsForWarehousesDetails => ResourceKey("GetReorderPointsForWarehousesDetails.g.sql");
            public static string GetInventoryAdjustmentsForWarehouses => ResourceKey("GetInventoryAdjustmentsForWarehouses.g.sql");
            public static string GetInventoryAdjustmentsForWarehousesDetails => ResourceKey("GetInventoryAdjustmentsForWarehousesDetails.g.sql");
        }
    }
}