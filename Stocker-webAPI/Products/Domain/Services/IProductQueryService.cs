using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Products.Domain.Model.Queries;

namespace Stocker_webAPI.Products.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    Task<IEnumerable<Product>> Handle(GetAllProductsByCategoryIdQuery query);
}