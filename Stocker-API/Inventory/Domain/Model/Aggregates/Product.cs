using Stocker_API.Inventory.Domain.Model.Entities;
using Stocker_API.Sales.Domain.Model.Aggregates;

namespace Stocker_API.Inventory.Domain.Model.Aggregates;

public partial class Product
{
    public Product(string name, string description, int categoryId, string photoUrl, decimal purchasePrice, decimal salePrice, int stock, DateOnly expiryDate)
    {
        Name = name;
        Description = description;
        CategoryId = categoryId;
        PhotoUrl = photoUrl;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        Stock = stock;
        ExpiryDate = expiryDate;
    }

    public int Id { get; }
    public string Name { get; private set; }

    public string Description { get; private set; }

    public Category Category { get; internal set; }
    
    public string PhotoUrl { get; private set; }
    public decimal PurchasePrice { get; private set; }
    public decimal SalePrice { get; private set; }
    public int Stock { get; private set; }
    public DateOnly ExpiryDate { get; private set; }
    public int CategoryId { get; private set; }    
    public ICollection<SaleDetail> SaleDetails { get; }
}