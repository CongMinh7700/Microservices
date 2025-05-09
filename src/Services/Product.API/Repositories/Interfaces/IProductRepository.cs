namespace Product.API.Repositories.Interfaces;

using Contracts.Common.Interfaces;
using Entities;
using Persistence;

public interface IProductRepository : IRepositoryBaseAsync<CatalogProduct, long, ProductContext>
{
    Task<IEnumerable<CatalogProduct>> GetProducts();

    Task<CatalogProduct> GetProduct(long id);

    Task<CatalogProduct> GetProductByNo(string productNo);

    Task CreateProduct(CatalogProduct product);

    Task UpdateProduct(CatalogProduct product);

    Task DeleteProduct(long id);
}
