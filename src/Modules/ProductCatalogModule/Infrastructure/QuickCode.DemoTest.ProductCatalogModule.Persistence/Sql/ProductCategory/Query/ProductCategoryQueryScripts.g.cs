namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductCategory
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.ProductCategory.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetByParent => ResourceKey("GetByParent.g.sql");
            public static string GetProductsForProductCategories => ResourceKey("GetProductsForProductCategories.g.sql");
            public static string GetProductsForProductCategoriesDetails => ResourceKey("GetProductsForProductCategoriesDetails.g.sql");
        }
    }
}