namespace Stocker_webAPI.Profiles.Interfaces.REST.Resources;

public record CreateSubscriptionResource(string Name, decimal MonthlyPrice, DateTime SubscriptionDate);