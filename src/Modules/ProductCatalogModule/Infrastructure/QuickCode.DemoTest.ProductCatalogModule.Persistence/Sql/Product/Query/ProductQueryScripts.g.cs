namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Product
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.Product.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetByCategory => ResourceKey("GetByCategory.g.sql");
            public static string GetByPriceRange => ResourceKey("GetByPriceRange.g.sql");
            public static string GetNewest => ResourceKey("GetNewest.g.sql");
            public static string GetProductImagesForProducts => ResourceKey("GetProductImagesForProducts.g.sql");
            public static string GetProductImagesForProductsDetails => ResourceKey("GetProductImagesForProductsDetails.g.sql");
            public static string GetProductReviewsForProducts => ResourceKey("GetProductReviewsForProducts.g.sql");
            public static string GetProductReviewsForProductsDetails => ResourceKey("GetProductReviewsForProductsDetails.g.sql");
            public static string GetProductSpecificationsForProducts => ResourceKey("GetProductSpecificationsForProducts.g.sql");
            public static string GetProductSpecificationsForProductsDetails => ResourceKey("GetProductSpecificationsForProductsDetails.g.sql");
        }
    }
}