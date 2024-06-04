namespace Stocker_webAPI.Profiles.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, string Name, decimal MonthlyPrice, DateTime Date);
