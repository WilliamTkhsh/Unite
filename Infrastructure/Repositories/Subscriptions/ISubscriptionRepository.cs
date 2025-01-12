using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Infrastructure.Repositories.Subscriptions
{
    public interface ISubscriptionRepository
    {
        public Task<IEnumerable<Subscription>> FindSubscriptionsByOfferAsync(string offerId);

        public Task<Subscription> FindSubscriptionByIdAsync(string id);

        public Task<Subscription> FindSubscriptionByUserIdAsync(string userId);

        public Task<Subscription> InsertSubscriptionAsync(Subscription Subscription);

        public Task<Subscription> UpdateSubscriptionAsync(string id, Subscription Subscription);

        public Task<int> DeleteSubscriptionAsync(string id);
    }
}
