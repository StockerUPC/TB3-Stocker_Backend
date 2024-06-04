using Stocker_webAPI.Products.Domain.Model.Commands;
using Stocker_webAPI.Products.Interfaces.REST.Resources;

namespace Stocker_webAPI.Products.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Name, resource.PhotoUrl, resource.SalePrice, resource.Quantity, resource.ExpiryDate, resource.CategoryId);
    }
}