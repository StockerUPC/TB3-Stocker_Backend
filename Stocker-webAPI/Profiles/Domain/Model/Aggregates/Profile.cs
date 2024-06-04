using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;
using Stocker_webAPI.Profiles.Domain.Model.Commands;

namespace Stocker_webAPI.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Username = new UserUsername();
        Password = new UserPassword();
        Email = new EmailAddress();
        Subscription = new UserSubscription();
    }

    public Profile(string username, string password, string email, DateTime subscriptionDate, string subscriptionPlan)
    {
        Username = new UserUsername(username);
        Password = new UserPassword(password);
        Email = new EmailAddress(email);
        Subscription = new UserSubscription(subscriptionDate, subscriptionPlan);
    }
    
    public Profile(CreateProfileCommand command)
    {
        Username = new UserUsername(command.Username);
        Password = new UserPassword(command.Password);
        Email = new EmailAddress(command.Email);
        Subscription = new UserSubscription(command.SubscriptionDate, command.SubscriptionPlan);
    }

    public int Id { get; }
    public UserUsername Username { get; private set; }
    public UserPassword Password { get; private set; }
    public EmailAddress Email { get; private set; }
    public UserSubscription Subscription { get; private set; }
    
    public string UserUsername => Username.Username;
    public string UserPassword => Password.Password;
    public string EmailAddress => Email.Address;
    public string UserSubscription => Subscription.FullSubscription;
}