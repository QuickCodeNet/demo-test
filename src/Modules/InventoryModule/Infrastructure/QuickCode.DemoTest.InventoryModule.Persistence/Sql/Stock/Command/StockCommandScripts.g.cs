namespace QuickCode.DemoTest.InventoryModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Stock
    {
        public static class Command
        {
            private const string _prefix = "InventoryModule.Stock.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string AdjustStock => ResourceKey("AdjustStock.g.sql");
        }
    }
}