namespace Stocker_webAPI.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string Username, string Password, string Email,  DateTime SubscriptionDate,
        string SubscriptionPlan);