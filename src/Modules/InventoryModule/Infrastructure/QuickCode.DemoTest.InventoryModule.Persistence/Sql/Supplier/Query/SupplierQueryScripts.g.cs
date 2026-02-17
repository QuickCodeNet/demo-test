namespace QuickCode.DemoTest.InventoryModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Supplier
    {
        public static class Query
        {
            private const string _prefix = "InventoryModule.Supplier.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
        }
    }
}