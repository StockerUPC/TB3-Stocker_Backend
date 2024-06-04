namespace Stocker_webAPI.Profiles.Domain.Model.ValueObjects;
public record SubscriptionMonthlyPrice(decimal MonthlyPrice)
{
    public SubscriptionMonthlyPrice() : this(decimal.Zero)
    {
    }
}