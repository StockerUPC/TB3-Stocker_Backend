using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Queries;
using Stocker_webAPI.Profiles.Domain.Model.Repositories;
using Stocker_webAPI.Profiles.Domain.Model.Services;

namespace Stocker_webAPI.Profiles.Application.Internal.QueryServices;

public class SubscriptionQueryService(ISubscriptionRepository subscriptionRepository) : ISubscriptionQueryService
{
    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
    {
        return await subscriptionRepository.ListAsync();
    }

    public async Task<Subscription?> Handle(GetSubscriptionByNameQuery query)
    {
        return await subscriptionRepository.FindSubscriptionByNameAsync(query.Name);
    }

    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
    {
        return await subscriptionRepository.FindByIdAsync(query.SubscriptionId);
    }
}