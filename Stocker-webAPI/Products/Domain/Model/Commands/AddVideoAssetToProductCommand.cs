namespace Stocker_webAPI.Products.Domain.Model.Commands;

public record AddVideoAssetToProductCommand(string VideoUrl, int ProductId);