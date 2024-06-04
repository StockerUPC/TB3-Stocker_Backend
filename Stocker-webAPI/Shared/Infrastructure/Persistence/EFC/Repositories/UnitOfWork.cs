namespace Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

using Stocker_webAPI.Shared.Domain.Repositories;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration;


public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}