using Domain.Models;

namespace Domain.Interfaces;

public interface ISubscriptionRepository
{
    Task<bool> AddSubscription(Subscriptions subscription);
    Task<bool> UpdateSubscription(int id,Subscriptions subscription);
    Task<bool> DeleteSubscription(int id);
    Task<Subscriptions> GetSubscription(int id);
    Task<List<Subscriptions>> GetSubscriptions();
    Task<bool> SubscriptionPatch(int id);
}
