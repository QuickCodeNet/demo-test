namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductReview
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.ProductReview.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByProduct => ResourceKey("GetByProduct.g.sql");
            public static string GetRecent => ResourceKey("GetRecent.g.sql");
        }
    }
}