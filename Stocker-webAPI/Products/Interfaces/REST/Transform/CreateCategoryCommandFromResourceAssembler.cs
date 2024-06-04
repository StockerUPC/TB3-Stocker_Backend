using Stocker_webAPI.Products.Domain.Model.Commands;
using Stocker_webAPI.Products.Interfaces.REST.Resources;

namespace Stocker_webAPI.Products.Interfaces.REST.Transform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}