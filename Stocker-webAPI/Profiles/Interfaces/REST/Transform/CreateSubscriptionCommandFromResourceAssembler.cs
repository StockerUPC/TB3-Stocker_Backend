using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Interfaces.REST.Resources;

namespace Stocker_webAPI.Profiles.Interfaces.REST.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(resource.Name, resource.MonthlyPrice, resource.SubscriptionDate);
    }
}