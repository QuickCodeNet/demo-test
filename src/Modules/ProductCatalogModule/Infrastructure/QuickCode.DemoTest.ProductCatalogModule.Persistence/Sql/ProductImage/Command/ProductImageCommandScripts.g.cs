namespace QuickCode.DemoTest.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductImage
    {
        public static class Command
        {
            private const string _prefix = "ProductCatalogModule.ProductImage.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetPrimary => ResourceKey("SetPrimary.g.sql");
        }
    }
}