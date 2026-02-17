namespace QuickCode.DemoTest.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ShipmentTrackingEvent
    {
        public static class Query
        {
            private const string _prefix = "ShippingModule.ShipmentTrackingEvent.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByShipment => ResourceKey("GetByShipment.g.sql");
        }
    }
}