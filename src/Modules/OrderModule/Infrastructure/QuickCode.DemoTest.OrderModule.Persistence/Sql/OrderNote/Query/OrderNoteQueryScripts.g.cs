namespace QuickCode.DemoTest.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class OrderNote
    {
        public static class Query
        {
            private const string _prefix = "OrderModule.OrderNote.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByOrder => ResourceKey("GetByOrder.g.sql");
        }
    }
}