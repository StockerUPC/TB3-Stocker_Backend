namespace Stocker_webAPI.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int Id, string Username, string Password, string Email, string Subscription);
