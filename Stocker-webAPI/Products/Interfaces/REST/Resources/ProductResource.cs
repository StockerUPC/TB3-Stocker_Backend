namespace Stocker_webAPI.Products.Interfaces.REST.Resources;

public record ProductResource(int Id, string Name, string PhotoUrl, decimal SalePrice, int Quantity, DateOnly ExpiryDate, CategoryResource Category, string Status);