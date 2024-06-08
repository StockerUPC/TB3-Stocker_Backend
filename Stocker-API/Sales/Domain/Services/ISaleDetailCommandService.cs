using Stocker_API.Sales.Domain.Model.Aggregates;
using Stocker_API.Sales.Domain.Model.Commands;

namespace Stocker_API.Sales.Domain.Services;

public interface ISaleDetailCommandService
{
    Task<SaleDetail?> Handle(CreateSaleDetailCommand command);
}