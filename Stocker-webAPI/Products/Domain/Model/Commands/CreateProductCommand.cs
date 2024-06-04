namespace Stocker_webAPI.Products.Domain.Model.Commands;

public record CreateProductCommand(string Name, string PhotoUrl, decimal SalePrice, int Quantity, DateOnly ExpiryDate, int CategoryId);