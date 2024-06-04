namespace Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

public record UserSubscription(DateTime SubscriptionDate, string SubscriptionPlan)
{
    public UserSubscription() : this(DateTime.Now, string.Empty)
    {
    }
    public string FullSubscription => $"{SubscriptionPlan},{SubscriptionDate}";
}