namespace Stocker_webAPI.Profiles.Domain.Model.Commands;

public record CreateSubscriptionCommand(string Name, decimal MonthlyPrice, DateTime Date);