using Stocker_API.Sales.Domain.Model.Aggregates;
using Stocker_API.Sales.Domain.Model.Commands;

namespace Stocker_API.Sales.Domain.Services;

public interface ISaleCommandService
{
    Task<Sale?> Handle(CreateSaleCommand command);
}