namespace QuickCode.DemoTest.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Shipment
    {
        public static class Query
        {
            private const string _prefix = "ShippingModule.Shipment.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByOrder => ResourceKey("GetByOrder.g.sql");
            public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
            public static string GetShipmentTrackingEventsForShipments => ResourceKey("GetShipmentTrackingEventsForShipments.g.sql");
            public static string GetShipmentTrackingEventsForShipmentsDetails => ResourceKey("GetShipmentTrackingEventsForShipmentsDetails.g.sql");
            public static string GetDeliveryExceptionsForShipments => ResourceKey("GetDeliveryExceptionsForShipments.g.sql");
            public static string GetDeliveryExceptionsForShipmentsDetails => ResourceKey("GetDeliveryExceptionsForShipmentsDetails.g.sql");
        }
    }
}