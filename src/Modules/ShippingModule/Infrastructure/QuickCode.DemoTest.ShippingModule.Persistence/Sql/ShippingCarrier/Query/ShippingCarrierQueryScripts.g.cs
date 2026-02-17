namespace QuickCode.DemoTest.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ShippingCarrier
    {
        public static class Query
        {
            private const string _prefix = "ShippingModule.ShippingCarrier.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetShipmentsForShippingCarriers => ResourceKey("GetShipmentsForShippingCarriers.g.sql");
            public static string GetShipmentsForShippingCarriersDetails => ResourceKey("GetShipmentsForShippingCarriersDetails.g.sql");
        }
    }
}