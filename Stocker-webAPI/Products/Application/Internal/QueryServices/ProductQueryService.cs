using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Products.Domain.Model.Queries;
using Stocker_webAPI.Products.Domain.Repositories;
using Stocker_webAPI.Products.Domain.Services;

namespace Stocker_webAPI.Products.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
  
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }

    
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();
    }
    
 
    public async Task<IEnumerable<Product>> Handle(GetAllProductsByCategoryIdQuery query)
    {
        return await productRepository.FindByCategoryIdAsync(query.CategoryId);
    }
}