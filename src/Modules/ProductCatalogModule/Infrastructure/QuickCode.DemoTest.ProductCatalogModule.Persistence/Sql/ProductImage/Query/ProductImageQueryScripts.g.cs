namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductImage
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.ProductImage.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByProduct => ResourceKey("GetByProduct.g.sql");
        }
    }
}