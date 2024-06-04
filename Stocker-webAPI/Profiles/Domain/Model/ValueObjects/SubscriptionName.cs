namespace Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

public record SubscriptionName(string Name)
{
    public SubscriptionName() : this(string.Empty)
    {
    }
}
