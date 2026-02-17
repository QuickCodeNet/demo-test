namespace QuickCode.DemoTest.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PaymentMethod
    {
        public static class Query
        {
            private const string _prefix = "OrderModule.PaymentMethod.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomer => ResourceKey("GetByCustomer.g.sql");
            public static string GetOrdersForPaymentMethods => ResourceKey("GetOrdersForPaymentMethods.g.sql");
            public static string GetOrdersForPaymentMethodsDetails => ResourceKey("GetOrdersForPaymentMethodsDetails.g.sql");
        }
    }
}