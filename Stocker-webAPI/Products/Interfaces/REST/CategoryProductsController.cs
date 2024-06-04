using System.Net.Mime;
using Stocker_webAPI.Products.Domain.Model.Queries;
using Stocker_webAPI.Products.Domain.Services;
using Stocker_webAPI.Products.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Stocker_webAPI.Products.Interfaces.REST;

[ApiController]
[Route("/api/v1/categories/{categoryId}/products")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryProductsController(IProductQueryService productQueryService) : ControllerBase
{
 
    [HttpGet]
    public async Task<IActionResult> GetProductsByCategoryId([FromRoute] int categoryId)
    {
        var getAllProductsByCategoryIdQuery = new GetAllProductsByCategoryIdQuery(categoryId);
        var products = await productQueryService.Handle(getAllProductsByCategoryIdQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}