using Stocker_webAPI.Products.Domain.Model.Entities;
using Stocker_webAPI.Products.Domain.Model.Queries;
using Stocker_webAPI.Products.Domain.Repositories;
using Stocker_webAPI.Products.Domain.Services;

namespace Stocker_webAPI.Products.Application.Internal.QueryServices;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
   
    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }
}