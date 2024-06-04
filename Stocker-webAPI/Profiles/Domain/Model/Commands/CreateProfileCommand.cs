namespace Stocker_webAPI.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string Username, string Password, string Email, DateTime SubscriptionDate, string SubscriptionPlan);