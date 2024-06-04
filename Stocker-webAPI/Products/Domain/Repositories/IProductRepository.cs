using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Shared.Domain.Repositories;

namespace Stocker_webAPI.Products.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId);
}