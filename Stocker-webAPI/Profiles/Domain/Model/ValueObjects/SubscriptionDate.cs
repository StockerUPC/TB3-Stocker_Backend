namespace Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

public record SubscriptionDate(DateTime Date)
{
    public SubscriptionDate() : this(DateTime.Now)
    {
    }
}