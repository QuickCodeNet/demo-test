namespace QuickCode.DemoTest.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class DeliveryAddress
    {
        public static class Query
        {
            private const string _prefix = "ShippingModule.DeliveryAddress.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomer => ResourceKey("GetByCustomer.g.sql");
            public static string GetShipmentsForDeliveryAddresses => ResourceKey("GetShipmentsForDeliveryAddresses.g.sql");
            public static string GetShipmentsForDeliveryAddressesDetails => ResourceKey("GetShipmentsForDeliveryAddressesDetails.g.sql");
        }
    }
}