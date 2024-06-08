using Stocker_API.Sales.Domain.Model.Entities;

namespace Stocker_API.Sales.Domain.Model.Aggregates;

public partial class Sale
{
    public Sale(int clientId, decimal totalAmount)
    {
        ClientId = clientId;
        TotalAmount = totalAmount;
    }

    public int Id { get; }
    public Client Client { get; internal set; }
    public decimal TotalAmount { get; private set; }
    public int ClientId { get; private set; }    
    
    public ICollection<SaleDetail> SaleDetails { get; }
}