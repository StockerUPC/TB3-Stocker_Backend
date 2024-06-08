using Stocker_API.Purchases.Domain.Model.Entities;

namespace Stocker_API.Purchases.Domain.Model.Aggregates;

public partial class Purchase
{
    public Purchase(int supplierId, decimal totalAmount)
    {
        SupplierId = supplierId;
        TotalAmount = totalAmount;
    }

    public int Id { get; }
    public Supplier Supplier { get; internal set; }
    public decimal TotalAmount { get; private set; }
    public int SupplierId{ get; private set; }    
    
    public ICollection<PurchaseDetail> PurchaseDetails { get; }
}