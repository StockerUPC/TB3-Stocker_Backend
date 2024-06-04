using Stocker_webAPI.Products.Domain.Model.Entities;
using Stocker_webAPI.Products.Interfaces.REST.Resources;

namespace Stocker_webAPI.Products.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        Console.WriteLine("Category Name is " + entity.Name);
        return new CategoryResource(entity.Id, entity.Name);
    }
}