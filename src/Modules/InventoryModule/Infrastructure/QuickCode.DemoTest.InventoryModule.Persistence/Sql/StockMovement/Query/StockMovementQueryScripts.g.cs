namespace QuickCode.DemoTest.InventoryModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class StockMovement
    {
        public static class Query
        {
            private const string _prefix = "InventoryModule.StockMovement.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByProduct => ResourceKey("GetByProduct.g.sql");
        }
    }
}