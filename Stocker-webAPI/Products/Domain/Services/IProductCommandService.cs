using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Products.Domain.Model.Commands;

namespace Stocker_webAPI.Products.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(AddVideoAssetToProductCommand command);
    Task<Product?> Handle(CreateProductCommand command);
}