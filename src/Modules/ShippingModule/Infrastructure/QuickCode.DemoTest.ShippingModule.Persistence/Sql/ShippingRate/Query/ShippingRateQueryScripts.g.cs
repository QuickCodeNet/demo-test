namespace QuickCode.DemoTest.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ShippingRate
    {
        public static class Query
        {
            private const string _prefix = "ShippingModule.ShippingRate.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCarrierAndZip => ResourceKey("GetByCarrierAndZip.g.sql");
        }
    }
}