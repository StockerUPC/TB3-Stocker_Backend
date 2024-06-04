using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Repositories;
using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Stocker_webAPI.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    public Task<Subscription?> FindSubscriptionByNameAsync(SubscriptionName name)
    {
        return Context.Set<Subscription>().Where(s =>s.Name == name).FirstOrDefaultAsync();
    }
}