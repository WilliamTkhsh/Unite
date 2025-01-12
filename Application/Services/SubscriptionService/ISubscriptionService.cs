using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Application.Services.SubscriptionService
{
    public interface ISubscriptionService
    {
        public Task<IEnumerable<Subscription>> GetSubscriptionsByOffer(string offerId);

        public Task<Subscription> GetSubscriptionByIdAsync(string id);

        public Task<Subscription> CreateSubscriptionAsync(Subscription Subscription);

        public Task<Subscription> UpdateSubscriptionAsync(string id, Subscription Subscription);

        public Task<int> DeleteSubscriptionAsync(string id);
    }
}
