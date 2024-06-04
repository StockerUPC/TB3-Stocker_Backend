using Stocker_webAPI.Products.Domain.Model.Commands;
using Stocker_webAPI.Products.Interfaces.REST.Resources;

namespace Stocker_webAPI.Products.Interfaces.REST.Transform;

public static class AddVideoAssetToProductCommandFromResourceAssembler
{
    public static AddVideoAssetToProductCommand ToCommandFromResource(AddVideoAssetToProductResource addVideoAssetToProductResource, int productId)
    {
        return new AddVideoAssetToProductCommand(addVideoAssetToProductResource.VideoUrl, productId);
    }
}