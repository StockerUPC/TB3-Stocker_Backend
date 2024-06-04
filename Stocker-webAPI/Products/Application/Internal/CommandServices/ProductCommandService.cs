using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Products.Domain.Model.Commands;
using Stocker_webAPI.Products.Domain.Repositories;
using Stocker_webAPI.Products.Domain.Services;
using Stocker_webAPI.Shared.Domain.Repositories;

namespace Stocker_webAPI.Products.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : IProductCommandService
{

    public async Task<Product?> Handle(AddVideoAssetToProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product is null) throw new Exception("Product not found");
        product.AddVideo(command.VideoUrl);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.PhotoUrl, command.SalePrice, command.Quantity, command.ExpiryDate, command.CategoryId);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        product.Category = category;
        return product;
    }   
}