using Stocker_API.Sales.Domain.Model.Queries;
using Stocker_API.Sales.Domain.Services;
using Stocker_API.Sales.Interfaces.REST.Resources;
using Stocker_API.Sales.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Stocker_API.Sales.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class SalesController(
    ISaleCommandService saleCommandService,
    ISaleQueryService saleQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleResource createSaleResource)
    {
        var createSaleCommand =
            CreateSaleCommandFromResourceAssembler.ToCommandFromResource(createSaleResource);
        var sale = await saleCommandService.Handle(createSaleCommand);
        if (sale is null) return BadRequest();
        var resource = SaleResourceFromEntityAssembler.ToResourceFromEntity(sale);
        return CreatedAtAction(nameof(GetSaleById), new { saleId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        var getAllSalesQuery = new GetAllSalesQuery();
        var sales = await saleQueryService.Handle(getAllSalesQuery);
        var resources = sales.Select(SaleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{saleId}")]
    public async Task<IActionResult> GetSaleById([FromRoute] int saleId)
    {
        var sale = await saleQueryService.Handle(new GetSaleByIdQuery(saleId));
        if (sale == null) return NotFound();
        var resource = SaleResourceFromEntityAssembler.ToResourceFromEntity(sale);
        return Ok(resource);
    }
}