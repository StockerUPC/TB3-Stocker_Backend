namespace Stocker_API.Inventory.Domain.Model.Commands;

public record AddVideoAssetToProductCommand(string VideoUrl, int ProductId);