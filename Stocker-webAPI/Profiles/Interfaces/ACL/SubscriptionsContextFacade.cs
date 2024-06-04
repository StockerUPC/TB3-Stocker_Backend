using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Domain.Model.Queries;
using Stocker_webAPI.Profiles.Domain.Model.Services;
using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

namespace Stocker_webAPI.Profiles.Interfaces.ACL;

public class SubscriptionsContextFacade(ISubscriptionCommandService subscriptionCommandService, ISubscriptionQueryService subscriptionQueryService)
{
    public async Task<int> CreateSubscription(string name, decimal monthlyPrice, DateTime date)
    {
        var createSubscriptionCommand = new CreateSubscriptionCommand( name,  monthlyPrice,  date);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        return subscription?.Id ?? 0;
    }
   
    public async Task<int> FetchSubscriptionIdByName(string name)
    {
        var getSubscriptionByNameQuery = new GetSubscriptionByNameQuery(new SubscriptionName(name));
        var subscription = await subscriptionQueryService.Handle(getSubscriptionByNameQuery);
        return subscription?.Id ?? 0;
    }
}