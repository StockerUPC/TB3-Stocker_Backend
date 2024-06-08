using Stocker_API.Sales.Domain.Model.Queries;
using Stocker_API.Sales.Domain.Services;
using Stocker_API.Sales.Interfaces.REST.Resources;
using Stocker_API.Sales.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Stocker_API.Sales.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class SalesDetailsController(
    ISaleDetailCommandService saleDetailCommandService,
    ISaleDetailQueryService saleDetailQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSaleDetailDetail([FromBody] CreateSaleDetailResource createSaleDetailResource)
    {
        var createSaleDetailCommand =
            CreateSaleDetailCommandFromResourceAssembler.ToCommandFromResource(createSaleDetailResource);
        var saleDetail = await saleDetailCommandService.Handle(createSaleDetailCommand);
        if (saleDetail is null) return BadRequest();
        var resource = SaleDetailResourceFromEntityAssembler.ToResourceFromEntity(saleDetail);
        return CreatedAtAction(nameof(GetSaleDetailById), new { saleDetailId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSaleDetails()
    {
        var getAllSaleDetailsQuery = new GetAllSaleDetailsQuery();
        var saleDetails = await saleDetailQueryService.Handle(getAllSaleDetailsQuery);
        var resources = saleDetails.Select(SaleDetailResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{saleDetailId}")]
    public async Task<IActionResult> GetSaleDetailById([FromRoute] int saleDetailId)
    {
        var saleDetail = await saleDetailQueryService.Handle(new GetSaleDetailByIdQuery(saleDetailId));
        if (saleDetail == null) return NotFound();
        var resource = SaleDetailResourceFromEntityAssembler.ToResourceFromEntity(saleDetail);
        return Ok(resource);
    }
}