namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductBrand
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.ProductBrand.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetProductsForProductBrands => ResourceKey("GetProductsForProductBrands.g.sql");
            public static string GetProductsForProductBrandsDetails => ResourceKey("GetProductsForProductBrandsDetails.g.sql");
        }
    }
}