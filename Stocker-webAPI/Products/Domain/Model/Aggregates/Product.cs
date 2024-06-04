using Stocker_webAPI.Products.Domain.Model.Entities;

namespace Stocker_webAPI.Products.Domain.Model.Aggregates;

public partial class Product
{
    public Product(string name, string photoUrl, decimal salePrice, int quantity, DateOnly expiryDate, int categoryId) : this()
    {
        Name = name;
        PhotoUrl = photoUrl;
        SalePrice = salePrice;
        Quantity = quantity;
        ExpiryDate = expiryDate;
        CategoryId = categoryId;
    }

    public int Id { get; }
    public string Name { get; private set; }

    public string PhotoUrl { get; private set; }
    
    public decimal SalePrice { get; private set; }

    public int Quantity { get; private set; }
    public DateOnly ExpiryDate { get; private set; }
    public Category Category { get; internal set; }
    public int CategoryId { get; private set; }    
}