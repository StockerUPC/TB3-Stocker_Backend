using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Interfaces.REST.Resources;

namespace Stocker_webAPI.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.UserUsername, entity.UserPassword, entity.EmailAddress, entity.UserSubscription);
    }
}