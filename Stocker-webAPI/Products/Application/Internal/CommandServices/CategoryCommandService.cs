using Stocker_webAPI.Products.Domain.Model.Commands;
using Stocker_webAPI.Products.Domain.Model.Entities;
using Stocker_webAPI.Products.Domain.Repositories;
using Stocker_webAPI.Products.Domain.Services;
using Stocker_webAPI.Shared.Domain.Repositories;

namespace Stocker_webAPI.Products.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICategoryCommandService
{
   
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command.Name);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
}