using Stocker_webAPI.Products.Domain.Model.Queries;
using Stocker_webAPI.Products.Domain.Services;
using Stocker_webAPI.Products.Interfaces.REST.Resources;
using Stocker_webAPI.Products.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Stocker_webAPI.Products.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource createProductResource)
    {
        var createProductCommand =
            CreateProductCommandFromResourceAssembler.ToCommandFromResource(createProductResource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await productQueryService.Handle(getAllProductsQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById([FromRoute] int productId)
    {
        var product = await productQueryService.Handle(new GetProductByIdQuery(productId));
        if (product == null) return NotFound();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(resource);
    }

    [HttpPost("{productId}/videos")]
    public async Task<IActionResult> AddVideoToProduct([FromBody] AddVideoAssetToProductResource addVideoAssetToProductResource,
        [FromRoute] int productId)
    {
        var addVideAssetToProductCommand =
            AddVideoAssetToProductCommandFromResourceAssembler.ToCommandFromResource(addVideoAssetToProductResource,
                productId);
        var product = await productCommandService.Handle(addVideAssetToProductCommand);
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productIdentifier = resource.Id }, resource);
    }
}