using Stocker_webAPI.Products.Domain.Model.Entities;
using Stocker_webAPI.Products.Domain.Repositories;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Stocker_webAPI.Products.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository;