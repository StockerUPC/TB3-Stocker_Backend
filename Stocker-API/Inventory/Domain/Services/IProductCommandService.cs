using Stocker_API.Inventory.Domain.Model.Aggregates;
using Stocker_API.Inventory.Domain.Model.Commands;

namespace Stocker_API.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(AddVideoAssetToProductCommand command);
    Task<Product?> Handle(CreateProductCommand command);
}