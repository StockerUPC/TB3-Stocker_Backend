using Stocker_webAPI.Products.Domain.Model.Entities;
using Stocker_webAPI.Products.Domain.Model.Queries;

namespace Stocker_webAPI.Products.Domain.Services;

public interface ICategoryQueryService
{
    Task<Category?> Handle(GetCategoryByIdQuery query);
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
}