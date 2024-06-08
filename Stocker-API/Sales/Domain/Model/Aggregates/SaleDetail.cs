using Stocker_API.Inventory.Domain.Model.Aggregates;
namespace Stocker_API.Sales.Domain.Model.Aggregates;

public partial class SaleDetail
{
    public SaleDetail(int saleId, int productId, decimal salePrice,int quantity, decimal subtotal)
    {
        SaleId = saleId;
        ProductId = productId;
        SalePrice = salePrice;
        Quantity = quantity;
        Subtotal = subtotal;
    }

    public int Id { get; }
    public Sale Sale { get; internal set; }
    
    public Product Product { get; internal set; }
    public decimal SalePrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Subtotal { get; private set; }
    public int SaleId { get; private set; }    
    public int ProductId { get; private set; }
}