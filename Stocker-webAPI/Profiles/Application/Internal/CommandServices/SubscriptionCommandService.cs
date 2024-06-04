using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Domain.Model.Repositories;
using Stocker_webAPI.Profiles.Domain.Model.Services;
using Stocker_webAPI.Shared.Domain.Repositories;

namespace Stocker_webAPI.Profiles.Application.Internal.CommandServices;

public class SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork) : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        try
        {
            await subscriptionRepository.AddAsync(subscription);
            await unitOfWork.CompleteAsync();
            return subscription;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the subscription: {e.Message}");
            return null;
        }
    }
}