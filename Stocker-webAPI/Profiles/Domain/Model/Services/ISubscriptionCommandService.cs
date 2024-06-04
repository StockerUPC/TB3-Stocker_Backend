using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

namespace Stocker_webAPI.Profiles.Domain.Model.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}