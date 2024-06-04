using Stocker_webAPI.Products.Domain.Model.Aggregates;
using Stocker_webAPI.Products.Domain.Repositories;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Stocker_webAPI.Products.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
 
    public new async Task<Product?> FindByIdAsync(int id) =>
        await Context.Set<Product>().Include(t => t.Category)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Product>> ListAsync()
    {
        return await Context.Set<Product>()
            .Include(product => product.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Product>()
            .Include(product => product.Category)
            .Where(product => product.CategoryId == categoryId)
            .ToListAsync();
    }
}