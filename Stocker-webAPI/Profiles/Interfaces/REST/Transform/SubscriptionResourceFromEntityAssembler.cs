using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Interfaces.REST.Resources;

namespace Stocker_webAPI.Profiles.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        return new SubscriptionResource(entity.Id, entity.SubscriptionName, entity.SubscriptionMonthlyPrice, entity.SubscriptionDate);
    }
}