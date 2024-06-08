using Stocker_API.Sales.Domain.Model.Aggregates;
using Stocker_API.Sales.Domain.Model.Commands;
using Stocker_API.Sales.Domain.Repositories;
using Stocker_API.Sales.Domain.Services;
using Stocker_API.Shared.Domain.Repositories;

namespace Stocker_API.Sales.Application.Internal.CommandServices;

public class SaleDetailCommandService(ISaleDetailRepository saleDetailRepository, ISaleRepository saleRepository, IUnitOfWork unitOfWork)
    : ISaleDetailCommandService
{
    
    public async Task<SaleDetail?> Handle(CreateSaleDetailCommand command)
    {
        var saleDetail = new SaleDetail(command.SaleId, command.ProductId, command.SalePrice, command.Quantity, command.Subtotal);
        await saleDetailRepository.AddAsync(saleDetail);
        await unitOfWork.CompleteAsync();
        var sale = await saleRepository.FindByIdAsync(command.SaleId);
        saleDetail.Sale = sale;
        return saleDetail;
    }   
}