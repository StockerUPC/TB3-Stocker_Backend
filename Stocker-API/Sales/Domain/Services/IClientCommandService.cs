using Stocker_API.Sales.Domain.Model.Commands;
using Stocker_API.Sales.Domain.Model.Entities;

namespace Stocker_API.Sales.Domain.Services;

public interface IClientCommandService
{
    public Task<Client?> Handle(CreateClientCommand command);
}