using Stocker_webAPI.Products.Domain.Model.Commands;
using Stocker_webAPI.Products.Domain.Model.Entities;

namespace Stocker_webAPI.Products.Domain.Services;

public interface ICategoryCommandService
{
    public Task<Category?> Handle(CreateCategoryCommand command);
}