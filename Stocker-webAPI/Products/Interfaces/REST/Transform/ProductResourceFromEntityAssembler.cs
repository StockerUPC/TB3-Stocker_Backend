using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Products.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace Stocker_webAPI.Products.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product product)
    {
        return new ProductResource(
            product.Id,
            product.Name,
            product.PhotoUrl,
            product.SalePrice,
            product.Quantity,
            product.ExpiryDate,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(product.Category),
            product.Status.GetDisplayName());
    }
}