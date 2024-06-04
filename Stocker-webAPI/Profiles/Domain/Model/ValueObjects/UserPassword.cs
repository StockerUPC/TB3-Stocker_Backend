namespace Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

public record UserPassword(string Password)
{
    public UserPassword() : this(string.Empty)
    {
    }
}