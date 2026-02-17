namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductSpecification
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.ProductSpecification.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByProduct => ResourceKey("GetByProduct.g.sql");
        }
    }
}