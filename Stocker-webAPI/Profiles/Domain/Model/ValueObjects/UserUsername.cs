namespace Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

public record UserUsername(string Username)
{
    public UserUsername() : this(string.Empty)
    {
    }
}