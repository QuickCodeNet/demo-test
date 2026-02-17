namespace QuickCode.DemoTest.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Order
    {
        public static class Command
        {
            private const string _prefix = "OrderModule.Order.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
        }
    }
}