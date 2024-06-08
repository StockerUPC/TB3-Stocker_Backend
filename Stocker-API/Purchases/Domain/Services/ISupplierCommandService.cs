using Stocker_API.Purchases.Domain.Model.Commands;
using Stocker_API.Purchases.Domain.Model.Entities;

namespace Stocker_API.Purchases.Domain.Services;

public interface ISupplierCommandService
{
    public Task<Supplier?> Handle(CreateSupplierCommand command);
}