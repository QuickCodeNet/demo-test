namespace QuickCode.DemoTest.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class BillingAddress
    {
        public static class Query
        {
            private const string _prefix = "OrderModule.BillingAddress.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomer => ResourceKey("GetByCustomer.g.sql");
            public static string GetOrdersForBillingAddresses => ResourceKey("GetOrdersForBillingAddresses.g.sql");
            public static string GetOrdersForBillingAddressesDetails => ResourceKey("GetOrdersForBillingAddressesDetails.g.sql");
        }
    }
}