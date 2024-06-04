using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;
using Stocker_webAPI.Profiles.Domain.Model.Commands;

namespace Stocker_webAPI.Profiles.Domain.Model.Aggregates;

public partial class Subscription
{
    public Subscription()
    {
        Name = new SubscriptionName();
        MonthlyPrice = new SubscriptionMonthlyPrice();
        Date = new SubscriptionDate();
    }
    public Subscription(string name, decimal monthlyPrice, DateTime subscriptionDate)
    {
        Name = new SubscriptionName(name);
        MonthlyPrice = new SubscriptionMonthlyPrice(monthlyPrice);
        Date = new SubscriptionDate(subscriptionDate);
    }
    
    public Subscription(CreateSubscriptionCommand command)
    {
        Name = new SubscriptionName(command.Name);
        MonthlyPrice = new SubscriptionMonthlyPrice(command.MonthlyPrice);
        Date = new SubscriptionDate(command.Date);
    }
    
    public int Id { get; }
    public SubscriptionName Name { get; private set; }
    public SubscriptionMonthlyPrice MonthlyPrice { get; private set; }
    public SubscriptionDate Date { get; private set; }
    
    public string SubscriptionName => Name.Name;
    public decimal SubscriptionMonthlyPrice => MonthlyPrice.MonthlyPrice; 
    public DateTime SubscriptionDate => Date.Date;
    
}