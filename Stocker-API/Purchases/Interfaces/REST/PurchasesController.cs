using Stocker_API.Purchases.Domain.Model.Queries;
using Stocker_API.Purchases.Domain.Services;
using Stocker_API.Purchases.Interfaces.REST.Resources;
using Stocker_API.Purchases.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Stocker_API.Purchases.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PurchasesController(
    IPurchaseCommandService purchaseCommandService,
    IPurchaseQueryService purchaseQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseResource createPurchaseResource)
    {
        var createPurchaseCommand =
            CreatePurchaseCommandFromResourceAssembler.ToCommandFromResource(createPurchaseResource);
        var purchase = await purchaseCommandService.Handle(createPurchaseCommand);
        if (purchase is null) return BadRequest();
        var resource = PurchaseResourceFromEntityAssembler.ToResourceFromEntity(purchase);
        return CreatedAtAction(nameof(GetPurchaseById), new { purchaseId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPurchases()
    {
        var getAllPurchasesQuery = new GetAllPurchasesQuery();
        var purchases = await purchaseQueryService.Handle(getAllPurchasesQuery);
        var resources = purchases.Select(PurchaseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{purchaseId}")]
    public async Task<IActionResult> GetPurchaseById([FromRoute] int purchaseId)
    {
        var purchase = await purchaseQueryService.Handle(new GetPurchaseByIdQuery(purchaseId));
        if (purchase == null) return NotFound();
        var resource = PurchaseResourceFromEntityAssembler.ToResourceFromEntity(purchase);
        return Ok(resource);
    }
}