using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Queries;

namespace Stocker_webAPI.Profiles.Domain.Model.Services;

public interface ISubscriptionQueryService
{
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query);
    Task<Subscription?> Handle(GetSubscriptionByNameQuery query);
    Task<Subscription?> Handle(GetSubscriptionByIdQuery query);
}