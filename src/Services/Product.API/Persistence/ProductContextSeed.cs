using Product.API.Entities;
using ILogger = Serilog.ILogger;

namespace Product.API.Persistence;

public class ProductContextSeed
{
    public static async Task SeedProductAsync(ProductContext productContext, ILogger logger)
    {
        if (!productContext.Products.Any())
        {
            productContext.AddRange(GetCatalogProducts());
            await productContext.SaveChangesAsync();
            logger.Information("Seeded data for Product DB associated with context {DbContextName}", nameof(ProductContext));

        }
    }

    public static IEnumerable<CatalogProduct> GetCatalogProducts()
    {
        return new List<CatalogProduct>()
        {
            new()
            {
                No = "Lotus",
                Name = "KillJoy",
                Summary = "Sentinal",
                Description = "Robot",
                Price = (decimal)123.5
            },
            new()
            {
                No = "Pearl",
                Name = "Raze",
                Summary = "Duelist",
                Description = "Japan",
                Price = (decimal)120.5
            }
        };
    }
}