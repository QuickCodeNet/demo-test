namespace QuickCode.DemoTest.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ShippingAddress
    {
        public static class Query
        {
            private const string _prefix = "OrderModule.ShippingAddress.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomer => ResourceKey("GetByCustomer.g.sql");
            public static string GetOrdersForShippingAddresses => ResourceKey("GetOrdersForShippingAddresses.g.sql");
            public static string GetOrdersForShippingAddressesDetails => ResourceKey("GetOrdersForShippingAddressesDetails.g.sql");
        }
    }
}