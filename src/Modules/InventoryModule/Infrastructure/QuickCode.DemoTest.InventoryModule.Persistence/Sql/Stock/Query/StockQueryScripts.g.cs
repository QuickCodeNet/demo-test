namespace QuickCode.DemoTest.InventoryModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Stock
    {
        public static class Query
        {
            private const string _prefix = "InventoryModule.Stock.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByProduct => ResourceKey("GetByProduct.g.sql");
            public static string GetByWarehouse => ResourceKey("GetByWarehouse.g.sql");
            public static string GetLowStock => ResourceKey("GetLowStock.g.sql");
        }
    }
}