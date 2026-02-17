namespace QuickCode.DemoTest.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Order
    {
        public static class Query
        {
            private const string _prefix = "OrderModule.Order.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomer => ResourceKey("GetByCustomer.g.sql");
            public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
            public static string GetPending => ResourceKey("GetPending.g.sql");
            public static string GetDailyRevenue => ResourceKey("GetDailyRevenue.g.sql");
            public static string GetOrderItemsForOrders => ResourceKey("GetOrderItemsForOrders.g.sql");
            public static string GetOrderItemsForOrdersDetails => ResourceKey("GetOrderItemsForOrdersDetails.g.sql");
            public static string GetOrderNotesForOrders => ResourceKey("GetOrderNotesForOrders.g.sql");
            public static string GetOrderNotesForOrdersDetails => ResourceKey("GetOrderNotesForOrdersDetails.g.sql");
        }
    }
}