namespace Stocker_webAPI.Products.Interfaces.REST.Resources;

public record CreateProductResource(string Name, string PhotoUrl, decimal SalePrice, int Quantity, DateOnly ExpiryDate, int CategoryId);