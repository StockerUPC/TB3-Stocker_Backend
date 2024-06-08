using Stocker_API.Purchases.Domain.Model.Queries;
using Stocker_API.Purchases.Domain.Services;
using Stocker_API.Purchases.Interfaces.REST.Resources;
using Stocker_API.Purchases.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Stocker_API.Purchases.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PurchasesDetailsController(
    IPurchaseDetailCommandService purchaseDetailCommandService,
    IPurchaseDetailQueryService purchaseDetailQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseDetailDetail([FromBody] CreatePurchaseDetailResource createPurchaseDetailResource)
    {
        var createPurchaseDetailCommand =
            CreatePurchaseDetailCommandFromResourceAssembler.ToCommandFromResource(createPurchaseDetailResource);
        var purchaseDetail = await purchaseDetailCommandService.Handle(createPurchaseDetailCommand);
        if (purchaseDetail is null) return BadRequest();
        var resource = PurchaseDetailResourceFromEntityAssembler.ToResourceFromEntity(purchaseDetail);
        return CreatedAtAction(nameof(GetPurchaseDetailById), new { purchaseDetailId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPurchaseDetails()
    {
        var getAllPurchaseDetailsQuery = new GetAllPurchaseDetailsQuery();
        var purchaseDetails = await purchaseDetailQueryService.Handle(getAllPurchaseDetailsQuery);
        var resources = purchaseDetails.Select(PurchaseDetailResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{purchaseDetailId}")]
    public async Task<IActionResult> GetPurchaseDetailById([FromRoute] int purchaseDetailId)
    {
        var purchaseDetail = await purchaseDetailQueryService.Handle(new GetPurchaseDetailByIdQuery(purchaseDetailId));
        if (purchaseDetail == null) return NotFound();
        var resource = PurchaseDetailResourceFromEntityAssembler.ToResourceFromEntity(purchaseDetail);
        return Ok(resource);
    }
}