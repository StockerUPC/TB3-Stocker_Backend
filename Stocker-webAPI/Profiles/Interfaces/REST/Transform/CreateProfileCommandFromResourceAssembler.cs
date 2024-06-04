using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Interfaces.REST.Resources;

namespace Stocker_webAPI.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.Username, resource.Password, resource.Email, resource.SubscriptionDate, resource.SubscriptionPlan);
    }
}